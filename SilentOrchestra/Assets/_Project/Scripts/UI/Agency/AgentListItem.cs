using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Orchestra;
using UnityEngine;

namespace SilentOrchestra.UI
{
    public class AgentListItem : ListItem
    {
        private Agent _agent;
        public void Initialize(ListController controller, Agent agent)
        {
            base.Initialize(controller);
        }
    }
}
