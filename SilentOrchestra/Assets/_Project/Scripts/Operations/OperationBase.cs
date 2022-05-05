using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.Operations
{
    public abstract class OperationBase : MonoBehaviour
    {
        public string OperationID;
    }

    public enum OperationStatus
    {
        Public,
        Exposed,
        
    }
}
