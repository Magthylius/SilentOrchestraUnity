using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.Shell
{
    [CreateAssetMenu(fileName = "New OccupationDatabase", menuName = "SilentOrchestra/Database/Occupation", order = 99)]
    public class OccupationDatabase : ScriptableObject
    {
        public string[] occupations;
    }
}
