using System.Collections;
using System.Collections.Generic;
using Magthylius;
using UnityEngine;

namespace SilentOrchestra.Shell
{
    [CreateAssetMenu(fileName = "New OrganizationDatabase", menuName = "SilentOrchestra/Database/Organization")]
    public class OrganizationDatabase : ScriptableObject
    {
        [Tooltip("Building objects, organization nouns. 'Agency' in CIA, 'Bureau' in FBI")]
        public string[] organizationBaseTerms;
        
        [Tooltip("Suffix or prefix object nouns. 'Central' in CIA, 'Federal' in FBI")]
        public string[] organizationAdjectiveTerms;
        
        [Tooltip("Suffix or prefix object nouns. 'Intelligence' in CIA")]
        public string[] organizationObjectTerms;
        
        [Tooltip("Suffix or prefix action nouns. 'Investigation' in FBI")]
        public string[] organizationActionTerms;
        
        public string RandomAgencyName
        {
            get
            {
                string name = string.Empty;

                string[] bas = RandomEx.Element(organizationBaseTerms,3,true);
                string[] adj = RandomEx.Element(organizationAdjectiveTerms,3,true);
                string[] obj = RandomEx.Element(organizationObjectTerms, 3, true);
                string[] act = RandomEx.Element(organizationActionTerms, 3, true);
                
                int randomChoice = Random.Range(0, 9);
                switch (randomChoice)
                {
                    case 0: name = $"{adj[0]} {obj[0]} {bas[0]}"; break;
                    case 1: name = $"{adj[0]} {bas[0]} of {adj[1]} {act[0]}"; break;
                    case 2: name = $"{adj[0]} {bas[0]} of {adj[1]} {obj[0]}"; break;
                    case 3: name = $"{adj[0]} {bas[0]} of {act[0]}"; break;
                    case 4: name = $"{bas[0]} of {adj[0]} {obj[0]}"; break;
                    case 5: name = $"{bas[0]} of {adj[0]} {act[0]}"; break;
                    case 6: name = $"{bas[0]} of {act[0]} and {act[1]}"; break;
                    case 7: name = $"{bas[0]} of {act[0]}, {act[1]} and {act[2]}"; break;
                    case 8: name = $"{adj[0]} {bas[0]} for {adj[1]} {obj[0]}"; break;
                }
                
                return name;
            }
        }
    }
}
