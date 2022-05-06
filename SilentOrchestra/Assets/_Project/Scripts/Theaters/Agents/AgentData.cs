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

        public static AgentStats Default =>
            new AgentStats {charisma = 10f, intuition = 10f, mobility = 10f, perception = 10f, execution = 10f, fortitude = 10f};
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
