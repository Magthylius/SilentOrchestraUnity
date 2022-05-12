using System.Collections;
using System.Collections.Generic;
using Magthylius;
using UnityEngine;

namespace SilentOrchestra.Shell
{
    [CreateAssetMenu(fileName = "New NameDatabase", menuName = "SilentOrchestra/Database/Name")]
    public class NameDatabase : ScriptableObject
    {
        public string[] codenames;
        public string[] firstNames;
        public string[] lastNames;
        
        public string RandomCodename => RandomEx.Element(codenames);
        public string RandomName => $"{RandomEx.Element(firstNames)} {RandomEx.Element(lastNames)}";
    }
}
