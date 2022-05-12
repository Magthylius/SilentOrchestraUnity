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
        
        public string GenerateAbbreviation(string fullName)
        {
            fullName = fullName.Trim();
            string[] split = fullName.Split(' ', ',');

            return GenerateAbbreviationInitials(split);
            
            //! TODO: Make generation algorithms better
            AbbreviationGenerationMethod method = (AbbreviationGenerationMethod)Random.Range(0, 3);

            switch (method)
            {
                case AbbreviationGenerationMethod.Initials: return GenerateAbbreviationInitials(split);
                case AbbreviationGenerationMethod.Doubles: return GenerateAbbreviationDoubles(split);
                case AbbreviationGenerationMethod.Groups: return GenerateAbbreviationGroups(split);
                default: return "UWU";
            }
        }

        public string GenerateAbbreviationInitials(string[] splitName)
        {
            string abbrev = string.Empty;
            foreach (string s in splitName)
            {
                if (string.IsNullOrWhiteSpace(s)) continue;
                if (char.IsUpper(s[0])) abbrev += s[0];
            }

            return abbrev;
        }
        
        public string GenerateAbbreviationDoubles(string[] splitName)
        {
            string abbrev = string.Empty;
            foreach (string s in splitName)
            {
                if (string.IsNullOrWhiteSpace(s) || !char.IsUpper(s[0])) continue;
                abbrev += s.Substring(0, 2);
            }

            return abbrev;
        }
        
        public string GenerateAbbreviationGroups(string[] splitName)
        {
            string abbrev = string.Empty;
            foreach (string s in splitName)
            {
                if (string.IsNullOrWhiteSpace(s) || !char.IsUpper(s[0])) continue;
                string word = s;
                string group = string.Empty;
                char curChar = word[0];
                
                while (group.Length < 3 || curChar.IsAnyOf('a', 'e', 'i', 'o', 'u'))
                {
                    group += curChar;
                    word = word.Remove(0, 1);
                    if (word.Length <= 0) break;
                    else curChar = word[0];
                }

                abbrev += group;
            }

            return abbrev;
        }

        public enum AbbreviationGenerationMethod
        {
            Initials = 0,
            Doubles = 1,
            Groups = 2
        }
    }
}
