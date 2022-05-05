using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.Agents
{
    public abstract class Agent : MonoBehaviour
    {
        public AgentInfo info;
        public AgentStats stats;

        public abstract void Tick();
    }
    
}
