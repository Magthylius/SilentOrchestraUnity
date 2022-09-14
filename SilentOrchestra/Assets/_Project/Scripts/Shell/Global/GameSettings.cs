using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.Shell
{
    public static class GameSettings
    {
        public const float kTotalDaysPerYear = 365.2425f;

        public static int AgentsPerAgency { get; set; }
        public static int AgenciesPerGovernment { get; set; }
        public static int GovernmentsPerTheater { get; set; }

        public static void ResetToDefaultSettings()
        {
            AgentsPerAgency = 10;
            AgenciesPerGovernment = 1;
            GovernmentsPerTheater = 4;

        }
    }
}
