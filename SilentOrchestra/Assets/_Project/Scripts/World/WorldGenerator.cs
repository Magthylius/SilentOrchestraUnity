using System;
using System.Collections.Generic;
using System.Linq;
using Magthylius;
using Magthylius.Components;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SilentOrchestra.World
{
    using SilentOrchestra.Shell;
    
    public class WorldGenerator : MonoBehaviour
    {
        [SerializeField] protected HexGridGenerator hexGridGenerator;

        private readonly Dictionary<Vector2Int, WorldTile> _allTiles = new();
        
        private TileDomain[,] _domains;
        private readonly Stack<TileDomain> _propagationStack = new();

        private TileDomain[,] _domainsCache;
        private (Vector2Int coordinates, WorldTileType type) _guessedTile;


        private void OnEnable()
        {
            hexGridGenerator.OnHexTileCreated += OnHexTileCreated;
            hexGridGenerator.OnGenerationCompleted += OnGenerationCompleted;
        }

        private void OnDisable()
        {
            hexGridGenerator.OnHexTileCreated -= OnHexTileCreated;
            hexGridGenerator.OnGenerationCompleted -= OnGenerationCompleted;
        }

        public void Initialize()
        {
            hexGridGenerator.GenerateGrid(GameSettings.WorldGridSize);
        }

        private void OnHexTileCreated(HexTile hexTile)
        {
            var worldTile = hexTile.gameObject.AddComponent<WorldTile>();
            _allTiles.Add(hexTile.Coordinates, worldTile);
        }

        private void OnGenerationCompleted()
        {
            foreach (var tileKvp in _allTiles)
            {
                tileKvp.Value.Initialize();
            }
            StartCollapseGeneration();
        }
        
        private void StartCollapseGeneration()
        {
            var cachedTypes = AllTileTypes;
            _domains = new TileDomain[GridSize.x, GridSize.y];
            for (int y = 0; y < GridSize.y; y++)
            {
                for (int x = 0; x < GridSize.x; x++)
                {
                    _domains[x, y] = new TileDomain(new Vector2Int(x,y), new List<WorldTileType>(cachedTypes));
                }
            }

            int loops = 0;
            while (_propagationStack.Count <= 0 && HasUncollapsedPotentials())
            {
                loops++;
                if (loops > 1000)
                {
                    Debug.LogWarning("potentials failed");
                    ColorAllCollapsedDomains();
                    return;
                }
                
                _domainsCache = CloneArray(in _domains);
                _guessedTile = CollapseRandomDomain();
                
                //! If bad propagation - revert and remove
                if (!HandlePropagation())
                {
                    print($"bad propagation: reverting on loop {loops}");
                    _domains = CloneArray(in _domainsCache);
                    _propagationStack.Clear();

                    var coords = _guessedTile.coordinates;
                    _domains[coords.x, coords.y].Potentials.Remove(_guessedTile.type);
                }

                print($"loop {loops}: {_propagationStack.Count} {HasUncollapsedPotentials()}");
            }

            TileDomain[,] CloneArray(in TileDomain[,] source)
            {
                int width = source.GetLength(0);
                int height = source.GetLength(1);
                
                var target = new TileDomain[width, height];
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        target[x, y] = source[x, y].Clone();
                    }
                }

                return target;
            }
        }
        
        private (Vector2Int coordinates, WorldTileType type) CollapseRandomDomain()
        {
            var randomX = Random.Range(0, GridSize.x);
            var randomY = Random.Range(0, GridSize.y);
            var domain = _domains[randomX, randomY];

            while (domain.Potentials.Count < 2)
            {
                randomX = Random.Range(0, GridSize.x);
                randomY = Random.Range(0, GridSize.y);
                domain = _domains[randomX, randomY];
            };

            var randomType = domain.Potentials.GetRandom();
            domain.ForceCollapse(randomType);
            print((domain.Coordinates, randomType));
            _propagationStack.Push(domain);
            return (domain.Coordinates, randomType);
        }

        private bool HandlePropagation()
        {
            int failsafe = 0;
            while (_propagationStack.Count > 0)
            {
                failsafe++;
                if (failsafe > 10000)
                {
                    Debug.LogWarning("propagation failed");
                    return false;
                }
                
                var domain = _propagationStack.Pop();
                var coords = domain.Coordinates;

                if (coords.x < GridSize.x - 1 && coords.y < GridSize.y - 1)
                {
                    var target = _domains[coords.x + 1, coords.y + 1];
                    if (PropagateToDomain(ref domain, ref target) < 0) return false;
                }
                
                if (coords.x < GridSize.x - 1)
                {
                    var target = _domains[coords.x + 1, coords.y];
                    if (PropagateToDomain(ref domain, ref target) < 0) return false;
                }
                
                if (coords.x < GridSize.x - 1 && coords.y > 0)
                {
                    var target = _domains[coords.x + 1, coords.y - 1];
                    if (PropagateToDomain(ref domain, ref target) < 0) return false;
                }
                
                if (coords.y > 0)
                {
                    var target = _domains[coords.x, coords.y - 1];
                    if (PropagateToDomain(ref domain, ref target) < 0) return false;
                }
                
                if (coords.x > 0)
                {
                    var target = _domains[coords.x - 1, coords.y];
                    if (PropagateToDomain(ref domain, ref target) < 0) return false;
                }
                
                if (coords.y < GridSize.y - 1)
                {
                    var target = _domains[coords.x, coords.y + 1];
                    if (PropagateToDomain(ref domain, ref target) < 0) return false;
                }
            }

            ColorAllCollapsedDomains();
            return true;
        }

        private int PropagateToDomain(ref TileDomain source, ref TileDomain target)
        {
            if (target.HasCollapsed) return 0;
            int potCount = target.Potentials.Count;
            GameSettings.WorldCollapseData.FromInclusives(ref target.Potentials, source.Potentials);
            if (target.Potentials.Count == 0) return -1;
            
            //! Target has potentials changed
            if (potCount != target.Potentials.Count)
            {
                _propagationStack.Push(target);
                return 1;
            }
            return 0;
        }

        private void ColorAllCollapsedDomains()
        {
            foreach (var domain in _domains)
            {
                if (domain.HasCollapsed)
                {
                    _allTiles[domain.Coordinates].Type = domain.Potentials[0];
                }
            }
        }

        private bool HasUncollapsedPotentials()
        {
            foreach (var domain in _domains)
            {
                if (domain.Potentials.Count > 1) return true;
                else if (domain.Potentials.Count < 1)
                {
                    Debug.LogWarning($"Broken domain! {domain.Coordinates}");
                    return false;
                }
            }

            return false;
        }

        private Vector2Int GridSize => GameSettings.WorldGridSize;
        private List<WorldTileType> AllTileTypes => Enum.GetValues(typeof(WorldTileType)).Cast<WorldTileType>().ToList();

        #region Declarations
        public class TileDomain
        {
            public Vector2Int Coordinates;
            public List<WorldTileType> Potentials;

            public TileDomain(Vector2Int coordinates, List<WorldTileType> potentials)
            {
                Coordinates = coordinates;
                Potentials = new List<WorldTileType>(potentials);
            }
            
            public void ForceCollapse(WorldTileType type)
            {
                Potentials.Clear();
                Potentials.Add(type);
            }

            public TileDomain Clone()
            {
                var clone = new TileDomain(Coordinates, Potentials);
                return clone;
            }

            public WorldTileType FirstType => Potentials.GetEnumerator().Current;

            public bool HasCollapsed => Potentials.Count == 1;
        }
        #endregion
    }
}