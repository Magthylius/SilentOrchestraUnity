using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.Shell
{
    [CreateAssetMenu(fileName = "New NameDatabase", menuName = "SilentOrchestra/Database/Name")]
    public class NameDatabase : ScriptableObject
    {
        public string[] codenames;
        public string[] firstNames;
        public string[] lastNames;
    }
}
