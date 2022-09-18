using System.Collections.Generic;
using Magthylius.Components;
using NaughtyAttributes;
using UnityEngine;

namespace SilentOrchestra.World
{
    using SilentOrchestra.Shell;
    
    public class WorldGenerator : MonoBehaviour
    {
        [SerializeField] protected HexGridGenerator hexGridGenerator;

        private readonly Dictionary<Vector2Int, WorldTile> _allTiles = new();

        private void OnEnable()
        {
            hexGridGenerator.OnHexTileCreated += OnHexTileCreated;
        }

        private void OnDisable()
        {
            hexGridGenerator.OnHexTileCreated -= OnHexTileCreated;
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
    }
}