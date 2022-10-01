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
                if (!_inclusiveSamples.ContainsKey(sample.selfType))
                {
                    _inclusiveSamples.Add(sample.selfType, sample.possibleTiles);
                }
            }
        }

        public void FromInclusives(ref List<WorldTileType> currentPotentials, List<WorldTileType> filters)
        {
            var potentials = new List<WorldTileType>(currentPotentials);
            foreach (var potential in potentials)
            {
                bool wantsRemoval = true;
                foreach (var filter in filters)
                {
                    if (_inclusiveSamples[potential].Contains(filter))
                    {
                        wantsRemoval = false;
                        break;
                    }
                }

                if (wantsRemoval) currentPotentials.Remove(potential);
            }
            Debug.Log($"{potentials.Count} vs {currentPotentials.Count}");

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
