using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.Agents
{
    public struct AgentStats
    {
        public float Charisma;
        public float Intuition;
        public float Mobility;
        public float Perception;
        public float Execution;

        public static AgentStats Default =>
            new AgentStats {Charisma = 10f, Intuition = 10f, Mobility = 10f, Perception = 10f, Execution = 10f};
    }

    public struct AgentInfo
    {
        public string Codename;
        public string AgentID;
        public PersonaInfo UndercoverPersona;
        public PersonaInfo RealPersona;
    }

    /// <summary>
    /// Used for information of a certain persona, whether real or fake
    /// </summary>
    public struct PersonaInfo
    {
        public string Name;
        public string Gender;
        public DateTime DateOfBirth;
        public string Occupation;

        public int GetAge(DateTime currentDate)
        {
            return currentDate.Year - DateOfBirth.Year;
        }
    }
}
