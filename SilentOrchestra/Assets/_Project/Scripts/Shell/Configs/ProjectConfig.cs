using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.Shell
{
    [CreateAssetMenu(fileName = "ProjectConfig", menuName = "SilentOrchestra/ProjectConfig", order = 100)]
    public class ProjectConfig : ScriptableObject
    {
        public int agentsPerAgency = 10;
        public int agenciesPerGovernment = 1;
        public int governmentsPerTheater = 4;
        public Vector2Int worldGridSize = new Vector2Int(100, 100);

        public WorldTileColor[] worldTileColors;

        public void OverrideGameSettings()
        {
            GameSettings.LoadFromProjectConfig(this);
        }
    }

    [System.Serializable]
    public struct WorldTileColor
    {
        public WorldTileType type;
        public Color color;
    }
}
