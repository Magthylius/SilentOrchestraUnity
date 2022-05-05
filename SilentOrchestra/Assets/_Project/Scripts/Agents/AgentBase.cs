using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.Agents
{
    public abstract class AgentBase : MonoBehaviour
    {
        public AgentInfo Info;
        public AgentStats Stats;

        public abstract void Tick();
    }
    
}
