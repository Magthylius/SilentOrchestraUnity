using System;
using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Agents;
using UnityEngine;

namespace SilentOrchestra.Operations
{
    public class Operation 
    {
        public OperationInfo Info;
        public OperationStatus Status;
        
        private Dictionary<string, Agent> _agents = new Dictionary<string, Agent>();
        private float _progress = 0f;

        public void Tick()
        {
            foreach (Agent agent in _agents.Values)
            {
                agent.Tick();
            }
        }

        /// <summary>Adds an agent to the operation.</summary>
        /// <param name="agent">Agent to add.</param>
        /// <returns>True if successful addition, false if not (or already exist).</returns>
        public bool TryAddAgent(Agent agent)
        {
            if (_agents.ContainsKey(agent.Info.agentID)) return false;
            _agents.Add(agent.Info.agentID, agent);
            agent.OperationContributed += OnOperationContributed;
            return true;
        }

        /// <summary>Removes an agent from the operation.</summary>
        /// <param name="agent">Agent to remove.</param>
        /// <returns>True if successful removal, false if not (or does not exist).</returns>
        public bool TryRemoveAgent(Agent agent)
        {
            if (!_agents.ContainsKey(agent.Info.agentID)) return false;
            _agents.Remove(agent.Info.agentID);
            agent.OperationContributed -= OnOperationContributed;
            return true;
        }

        #region Events

        public void OnOperationContributed(Agent contributingAgent, float progress)
        {
            
        }

        #endregion
    }
}
