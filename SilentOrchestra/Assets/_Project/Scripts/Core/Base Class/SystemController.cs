using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.Core
{
    public abstract class SystemController : MonoBehaviour
    {
        protected CoreSystem Core;
        
        public virtual void Initialize(CoreSystem coreSystem)
        {
            Core = coreSystem;
        }
    }
}
