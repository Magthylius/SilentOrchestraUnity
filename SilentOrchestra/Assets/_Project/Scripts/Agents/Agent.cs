using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.Agents
{
    public class Agent 
    {
        public AgentInfo Info;
        public AgentStats Stats;

        public Action<Agent, float> OperationContributed;

        public void Tick() { }

        public static Agent RandomAgent
        {
            get
            {
                Agent randomAgent = new Agent();
                AgentInfo info = new AgentInfo();
                AgentStats stats = AgentStats.Default;

                PersonaInfo realPersona = new PersonaInfo();
                return randomAgent;
            }
        }
    }
    
}
