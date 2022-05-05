using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Agents;
using SilentOrchestra.Operations;
using UnityEngine;

namespace SilentOrchestra.Agencies
{
    public class Agency : MonoBehaviour
    {
        private List<Agent> _agent = new List<Agent>();
        private List<Operation> _operations = new List<Operation>();
    }
}
