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
    }
    
}
