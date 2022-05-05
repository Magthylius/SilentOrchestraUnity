using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.Agents
{
    public class Agent : MonoBehaviour
    {
        public AgentInfo info;
        public AgentStats stats;

        public Action<Agent, float> OperationContributed;

        public void Tick() { }
    }
    
}
