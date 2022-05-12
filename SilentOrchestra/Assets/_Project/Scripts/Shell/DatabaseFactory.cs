using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Magthylius;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SilentOrchestra.Shell
{
    public class DatabaseFactory : SoftSingleton<DatabaseFactory>
    {
        [SerializeField] private NameDatabase names;
        [SerializeField] private OrganizationDatabase organization;
        [SerializeField] private OccupationDatabase occupations;
        [SerializeField] private SettingsDatabase settings;

        public static string RandomCodename => Instance.names.RandomCodename;
        public static string RandomName => Instance.names.RandomName;
        public static string RandomID => Random.Range(1, 10000).ToString();
        public static float RandomAge => Instance.settings.RandomAge;
        public static string RandomAgencyName => Instance.organization.RandomAgencyName;
        public static string GenerateAbbreviation(string name) => Instance.organization.GenerateAbbreviation(name);
        public static string RandomOccupation => Instance.occupations.RandomOccupation;

        
    }
}
