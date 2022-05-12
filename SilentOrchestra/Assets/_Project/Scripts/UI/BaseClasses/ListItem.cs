using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.UI
{
    public class ListItem : MonoBehaviour
    {
        protected ListController Controller;
        
        public virtual void Initialize(ListController controller)
        {
            Controller = controller;
        }
        
        public virtual void Deinitialize() { }
    }
}
