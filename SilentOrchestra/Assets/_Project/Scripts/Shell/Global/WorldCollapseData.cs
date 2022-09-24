using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SilentOrchestra.Shell
{
    [CreateAssetMenu(fileName = "WorldCollapseData", menuName = "SilentOrchestra/WorldCollapseData")]
    public class WorldCollapseData : ScriptableObject
    {
        public List<WorldTileCollapseSample> samples = new();

        private Dictionary<WorldTileType, List<WorldTileType>> _inclusiveSamples = new();
        private Dictionary<WorldTileType, List<WorldTileType>> _exclusiveSamples = new();
        private Dictionary<WorldTileType, (List<WorldTileType> inclusives, List<WorldTileType> exclusives)> _tabulatedSamples = new();
        
        public void TabulateSamples()
        {
            var allTypesCache = AllTileTypes;
            foreach (var sample in samples)
            {
                if (!_tabulatedSamples.ContainsKey(sample.selfType))
                {
                    var inclusives = new List<WorldTileType>(sample.possibleTiles);
                    var exclusives = new List<WorldTileType>(allTypesCache).Except(inclusives).ToList();
                    _tabulatedSamples.Add(sample.selfType, (inclusives, exclusives));
                }
            }
        }

        public void FromInclusives(ref List<WorldTileType> currentPotentials, List<WorldTileType> filters)
        {
            foreach (var filter in filters)
            {
                foreach (var incKvp in _inclusiveSamples)
                {
                    if (!currentPotentials.Contains(incKvp.Key)) continue;
                    if (!incKvp.Value.Contains(filter)) currentPotentials.Remove(incKvp.Key);
                }
            }
        }

        public bool UpdatePotentials(WorldTileType type, ref HashSet<WorldTileType> currentPotentials)
        {
            foreach (var sample in samples)
            {
                if (sample.selfType == type)
                {
                    currentPotentials.IntersectWith(new HashSet<WorldTileType>(sample.possibleTiles));
                    return true;
                }
            }

            return false;
        }
        
        public static List<WorldTileType> AllTileTypes => Enum.GetValues(typeof(WorldTileType)).Cast<WorldTileType>().ToList();
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
