using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.Orchestra
{
    [System.Serializable]
    public class Agency 
    {
        public List<Agent> Agents { get; private set; } = new List<Agent>();
        public List<Operation> Operations { get; private set; } = new List<Operation>();

        private string _name;
        [NonSerialized] private Government _belongingGovernment;

        public Agency(int agentAmount)
        {
            RegenerateAgents(agentAmount);
        }

        public void RegenerateAgents(int amount)
        {
            Agents = new List<Agent>();
            for (int i = 0; i < amount; i++)
            {
                Agent agent = Agent.RandomAgent;
                Agents.Add(agent);
            }
        }

        public string Name => _name;
        public Government Government => _belongingGovernment;
        public int AgentCount => Agents.Count;
    }
}
