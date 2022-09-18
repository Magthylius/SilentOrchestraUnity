using System.Collections;
using System.Collections.Generic;
using Magthylius.Components;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;

namespace SilentOrchestra.World.Editors
{
    public class WorldTileSamplerGenerator : WorldGenerator
    {
        [SerializeField] private Vector2Int gridSize;
        [SerializeField] private WorldTile[] sampleTiles;
        [SerializeField, Expandable] private WorldCollapseData collapseData;
        
        [Button("Generate Grid")]
        public void GenerateGridInEditor()
        {
            hexGridGenerator.GenerateGrid(gridSize, true);
            foreach (var hexTileKvp in hexGridGenerator.HexTiles)
            {
                hexTileKvp.Value.gameObject.AddComponent<WorldTileSampler>();
            }
        }
        
        [Button("Destroy Grid")]
        public void DestroyGridInEditor()
        {
            hexGridGenerator.DestroyGrid(true);
        }
        
        [Button("Generate Sample Data")]
        public void GenerateSampleData()
        {
            foreach (var tile in sampleTiles)
            {
                collapseData.PopulateData(tile);
            }

            collapseData.CleanUpData();
            EditorUtility.SetDirty(collapseData);
        }
    }
}
