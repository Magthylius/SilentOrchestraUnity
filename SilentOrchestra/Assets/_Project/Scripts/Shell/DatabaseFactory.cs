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
        [SerializeField] private NameDatabase nameDatabase;

        public static string RandomName
        {
            get
            {
                string firstName = RandomEx.Element(Instance.nameDatabase.firstNames);
                string lastName = RandomEx.Element(Instance.nameDatabase.lastNames);
                return $"{firstName} {lastName}";
            }
        }

        public static DateTime RandomAge
        {
            get
            {
                Vector2 ageRange = GameSettings.AgentAgeRange;
                float randomYearsOld = RandomEx.Range(ageRange);
                return DateTime.Today;
            }
        }
    }
}
