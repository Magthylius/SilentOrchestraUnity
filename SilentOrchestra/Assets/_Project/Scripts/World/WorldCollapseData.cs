using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Magthylius.Collections;
using Magthylius.Components;
using UnityEngine;

namespace SilentOrchestra.World
{
    [CreateAssetMenu(fileName = "WorldCollapseData", menuName = "SilentOrchestra/WorldCollapseData")]
    public class WorldCollapseData : ScriptableObject
    {
        public List<WorldTileCollapseSample> samples = new();

        public void PopulateData(WorldTile tile)
        {
            var type = tile.Type;
            var sample = samples.FirstOrDefault(first => first.selfType == type);
            if (sample == default)
            {
                sample = new WorldTileCollapseSample(type);
                samples.Add(sample);
            }
            
            sample.possibleTiles.Add(tile.TopRight.Type);
            sample.possibleTiles.Add(tile.Right.Type);
            sample.possibleTiles.Add(tile.BottomRight.Type);
            sample.possibleTiles.Add(tile.BottomLeft.Type);
            sample.possibleTiles.Add(tile.Left.Type);
            sample.possibleTiles.Add(tile.TopLeft.Type);
        }

        public void CleanUpData()
        {
            samples.ForEach(sample => sample.CleanUpPossibles());
        }
    }

    [Serializable]
    public class WorldTileCollapseSample
    {
        public WorldTileType selfType;
        public List<WorldTileType> possibleTiles;

        public WorldTileCollapseSample(WorldTileType type)
        {
            selfType = type;
            possibleTiles = new List<WorldTileType>();
        }

        public void CleanUpPossibles()
        {
            ClearListDuplicates(ref possibleTiles);
        }

        private void ClearListDuplicates(ref List<WorldTileType> list) => list = list.Distinct().ToList();
    }
}
