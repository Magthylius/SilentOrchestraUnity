using System;
using Magthylius.Components;
using UnityEngine;

namespace SilentOrchestra.World
{
    public class WorldGenerator : MonoBehaviour
    {
        [SerializeField] private HexGridGenerator hexGridGenerator;

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
        }
    }
}