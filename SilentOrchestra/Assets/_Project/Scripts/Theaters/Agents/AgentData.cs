using System;
using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Shell;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SilentOrchestra.Theaters
{
    [Serializable]
    public struct AgentStats
    {
        public float charisma;
        public float intuition;
        public float mobility;
        public float perception;
        public float execution;
        public float fortitude;
        public float discretion;

        public static AgentStats Default => new AgentStats 
        {
            charisma = 0.5f, intuition = 0.5f, mobility = 0.5f, perception = 0.5f, 
            execution = 0.5f, fortitude = 0.5f, discretion = 0.5f
        };

        public static AgentStats Talentless => new AgentStats
        {
            charisma = 0.1f, intuition = 0.1f, mobility = 0.1f, perception = 0.1f, 
            execution = 0.1f, fortitude = 0.1f, discretion = 0.1f
        };

        public static AgentStats Randomized
        {
            get
            {
                AgentStats stats = AgentStats.Talentless;
                
                int statAmount = 7;
                int levelAmount = 4;
                float levelIncrement = 0.1f;
                
                int roundCount = statAmount * levelAmount;
                float statCap = levelIncrement * levelAmount;
                for (int round = 0; round < roundCount; round++)
                {
                    int randomStat = Random.Range(0, statAmount);
                    switch (randomStat)
                    {
                        case 0: IncrementStat(ref stats.charisma); break;
                        case 1: IncrementStat(ref stats.intuition); break;
                        case 2: IncrementStat(ref stats.mobility); break;
                        case 3: IncrementStat(ref stats.perception); break;
                        case 4: IncrementStat(ref stats.execution); break;
                        case 5: IncrementStat(ref stats.fortitude); break;
                        case 6: IncrementStat(ref stats.discretion); break;
                    }
                }
                
                return stats;

                void IncrementStat(ref float stat) => stat = Mathf.Min(stat + levelIncrement, statCap);
            }
        }
    }

    [Serializable]
    public struct AgentInfo
    {
        public string codename;
        public string agentID;
        public PersonaInfo undercoverPersona;
        public PersonaInfo realPersona;
    }

    /// <summary>
    /// Used for information of a certain persona, whether real or fake.
    /// </summary>
    [Serializable]
    public struct PersonaInfo
    {
        public string name;
        public string gender;
        public string occupation;
        public DateTime DateOfBirth;

        public int Age =>
            Mathf.RoundToInt((float)(GameRuntimeData.CurrentDateTime - DateOfBirth).TotalDays / GameSettings.kTotalDaysPerYear);

        public static PersonaInfo Randomized
        {
            get
            {
                PersonaInfo info = new PersonaInfo();
                info.name = DatabaseFactory.RandomName;
                info.gender = Random.Range(0, 2) == 0 ? "Male" : "Female";
                info.occupation = DatabaseFactory.RandomOccupation;

                float randomAgeInDays = DatabaseFactory.RandomAge * GameSettings.kTotalDaysPerYear;
                info.DateOfBirth = GameRuntimeData.CurrentDateTime - TimeSpan.FromDays(randomAgeInDays);
                return info;
            }
        }
        
        public enum AgentRoles
        {
            Assassin,
            Saboteur,
            Smuggler,
            Provocateur,
            Intelligence,
            Principal,
            Sleeper,
            DoubleAgent,
            TripleAgent,
            QuadrupleAgent
        }

        public enum AgentGenders
        {
            Male,
            Female,
            NonBinary
        }
    }
}
