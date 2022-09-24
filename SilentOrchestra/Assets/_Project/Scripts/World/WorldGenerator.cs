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
        private readonly Queue<WorldTile> _propagationQueue = new();

        private TileDomain[,] _domains;

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
            var gridSize = GameSettings.WorldGridSize;
            var allTypes = Enum.GetValues(typeof(WorldTileType)).Cast<WorldTileType>().ToList();
            var propagationStack = new Stack<TileDomain>();

            _domains = new TileDomain[gridSize.x, gridSize.y];
            for (int y = 0; y < gridSize.y; y++)
            {
                for (int x = 0; x < gridSize.x; x++)
                {
                    _domains[x, y] = new TileDomain(new Vector2Int(x,y), new List<WorldTileType>(allTypes));
                }
            }

            void CollapseRandomDomain()
            {
                var randomX = Random.Range(0, gridSize.x);
                var randomY = Random.Range(0, gridSize.y);
                _domains[randomX, randomY].ForceCollapse(allTypes.GetRandom());
                
                propagationStack.Push(_domains[randomX, randomY]);
                HandlePropagation();
            }

            void HandlePropagation()
            {
                while (propagationStack.Count > 0)
                {
                    var domain = propagationStack.Pop();
                    var coords = domain.Coordinates;

                    if (coords.x < gridSize.x - 1 && coords.y < gridSize.y - 1)
                    {
                        var target = _domains[coords.x + 1, coords.y + 1];
                        PropagateToDomain(ref domain, ref target);
                    }
                    
                    if (coords.x < gridSize.x - 1)
                    {
                        var target = _domains[coords.x + 1, coords.y];
                        PropagateToDomain(ref domain, ref target);
                    }
                    
                    if (coords.x < gridSize.x - 1 && coords.y > 0)
                    {
                        var target = _domains[coords.x + 1, coords.y - 1];
                        PropagateToDomain(ref domain, ref target);
                    }
                    
                    if (coords.y > 0)
                    {
                        var target = _domains[coords.x, coords.y - 1];
                        PropagateToDomain(ref domain, ref target);
                    }
                    
                    if (coords.x > 0)
                    {
                        var target = _domains[coords.x - 1, coords.y];
                        PropagateToDomain(ref domain, ref target);
                    }
                    
                    if (coords.y < gridSize.y - 1)
                    {
                        var target = _domains[coords.x, coords.y + 1];
                        PropagateToDomain(ref domain, ref target);
                    }
                }
            }

            int PropagateToDomain(ref TileDomain source, ref TileDomain target)
            {
                if (target.HasCollapsed) return 0;
                int potCount = target.Potentials.Count;
                GameSettings.WorldCollapseData.FromInclusives(ref target.Potentials, source.Potentials);

                if (target.Potentials.Count == 0) return -1;
                if (potCount > target.Potentials.Count)
                {
                    propagationStack.Push(target);
                    return 1;
                }
                return 0;
            }
        }

        public void QueuePropagation(List<WorldTile> worldTiles)
        {
            worldTiles.ForEach(tile => _propagationQueue.Enqueue(tile));
        }

        public class TileDomain
        {
            public Vector2Int Coordinates;
            public List<WorldTileType> Potentials;

            public TileDomain(Vector2Int coordinates, List<WorldTileType> potentials)
            {
                Coordinates = coordinates;
                Potentials = potentials;
            }
            
            public void ForceCollapse(WorldTileType type)
            {
                Potentials.Clear();
                Potentials.Add(type);
            }

            public WorldTileType FirstType => Potentials.GetEnumerator().Current;
            public bool HasCollapsed => Potentials.Count == 1;
        }
    }
}