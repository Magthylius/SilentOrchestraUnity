using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.Shell
{
    public static class GameSettings
    {
        public const float kTotalDaysPerYear = 365.2425f;
        
        private static int _agentsPerAgency;
        public static int AgentsPerAgency
        {
            get => _agentsPerAgency;
            set => _agentsPerAgency = value;
        }
        
        private static int _agenciesPerGovernment;
        public static int AgenciesPerGovernment
        {
            get => _agenciesPerGovernment;
            set => _agenciesPerGovernment = value;
        }

        private static int _governmentsPerTheater;
        public static int GovernmentsPerTheater
        {
            get => _governmentsPerTheater;
            set => _governmentsPerTheater = value;
        }

        public static void ResetToDefaultSettings()
        {
            AgentsPerAgency = 10;
            AgenciesPerGovernment = 1;
            GovernmentsPerTheater = 4;

        }
    }
}
