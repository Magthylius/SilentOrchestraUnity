using System;
using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Agents;
using UnityEngine;

namespace SilentOrchestra.Operations
{
    public abstract class Operation : MonoBehaviour
    {
        public OperationInfo info;
        public OperationStatus status;
        
        private List<Agent> _agents = new List<Agent>();
        private float _progress = 0f;
    }

    public enum OperationStatus
    {
        Public,
        Exposed
    }

    [Serializable]
    public struct OperationInfo
    {
        public string ID;
        public string Name;
    }
}
