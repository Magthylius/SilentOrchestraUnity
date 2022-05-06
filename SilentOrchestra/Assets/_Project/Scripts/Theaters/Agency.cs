using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.Theaters
{
    public class Agency 
    {
        private List<Agent> _agents = new List<Agent>();
        private List<Operation> _operations = new List<Operation>();

        public Agency(int agentAmount)
        {
            RegenerateAgents(agentAmount);
        }

        public void RegenerateAgents(int amount)
        {
            _agents = new List<Agent>();
            for (int i = 0; i < amount; i++)
            {
                Agent agent = new Agent();
                _agents.Add(agent);
            }
        }
    }
}
