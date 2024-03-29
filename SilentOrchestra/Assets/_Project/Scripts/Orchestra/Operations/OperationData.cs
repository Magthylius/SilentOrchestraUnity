using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.Orchestra
{
    
    public enum OperationStatus
    {
        Public,
        Classified,
        Proposed,
    }

    [Serializable]
    public struct OperationInfo
    {
        public string id;
        public string name;
    }
}
