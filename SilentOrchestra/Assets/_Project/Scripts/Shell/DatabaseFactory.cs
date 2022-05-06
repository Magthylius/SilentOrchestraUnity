using System;
using System.Collections;
using System.Collections.Generic;
using Magthylius;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SilentOrchestra.Shell
{
    public class DatabaseFactory : SoftSingleton<DatabaseFactory>
    {
        [SerializeField] private NameDatabase names;
        [SerializeField] private OccupationDatabase occupations;
        [SerializeField] private SettingsDatabase settings;

        public static string RandomCodename => 
            RandomEx.Element(Instance.names.codenames);
        
        public static string RandomName =>
            $"{RandomEx.Element(Instance.names.firstNames)} {RandomEx.Element(Instance.names.lastNames)}";

        public static string RandomOccupation =>
            RandomEx.Element(Instance.occupations.occupations);

        public static float RandomAge =>
            Instance.settings.GetAge(Random.Range(0f, 1f));
    }
}
