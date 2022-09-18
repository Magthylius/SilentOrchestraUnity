using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.Shell
{
    public static class GameSettings
    {
        public const float KTotalDaysPerYear = 365.2425f;

        public static int AgentsPerAgency = 10;
        public static int AgenciesPerGovernment = 1;
        public static int GovernmentsPerTheater = 4;

        public static Vector2Int WorldGridSize = new Vector2Int(100, 100);

        public static readonly Dictionary<WorldTileType, Color> WorldTileColors = new();

        public static void ResetToDefaultSettings()
        {
            AgentsPerAgency = 10;
            AgenciesPerGovernment = 1;
            GovernmentsPerTheater = 4;
            
            WorldGridSize = new Vector2Int(100, 100);
        }

        public static void LoadFromProjectConfig(ProjectConfig config)
        {
            AgentsPerAgency = config.agentsPerAgency;
            AgenciesPerGovernment = config.agenciesPerGovernment;
            GovernmentsPerTheater = config.governmentsPerTheater;
            WorldGridSize = config.worldGridSize;

            foreach (var tileColor in config.worldTileColors)
            {
                if (WorldTileColors.ContainsKey(tileColor.type)) continue;;
                WorldTileColors.Add(tileColor.type, tileColor.color);
            }
        }
    }
}
