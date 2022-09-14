using System;
using System.Collections.Generic;
using Magthylius.Components;
using UnityEngine;

namespace SilentOrchestra.World
{
    public class WorldGenerator : MonoBehaviour
    {
        [SerializeField] private HexGridGenerator hexGridGenerator;

        private readonly Dictionary<Vector2Int, WorldTile> _allTiles = new();

        private void OnEnable()
        {
            hexGridGenerator.OnHexTileCreated += OnHexTileCreated;
            hexGridGenerator.GenerateGrid();
        }

        private void OnDisable()
        {
            hexGridGenerator.OnHexTileCreated -= OnHexTileCreated;
        }

        private void OnHexTileCreated(HexTile hexTile)
        {
            var worldTile = hexTile.gameObject.AddComponent<WorldTile>();
            _allTiles.Add(hexTile.Coordinates, worldTile);
        }
    }
}