using System;
using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Shell;
using UnityEngine;

namespace SilentOrchestra.Agents
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

    public enum AgentRole
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

        public int GetAge(DateTime currentDate)
        {
            return currentDate.Year - DateOfBirth.Year;
        }

        public PersonaInfo Randomized
        {
            get
            {
                PersonaInfo info = new PersonaInfo();
                info.name = DatabaseFactory.RandomName;
                return info;
            }
        }
    }
}
