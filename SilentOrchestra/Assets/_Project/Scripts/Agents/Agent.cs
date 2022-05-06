using System;
using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Shell;
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

                info.codename = DatabaseFactory.RandomCodename;
                //info.agentID = 
                info.realPersona = PersonaInfo.Randomized;
                info.undercoverPersona = PersonaInfo.Randomized;
                return randomAgent;
            }
        }
    }
    
}
