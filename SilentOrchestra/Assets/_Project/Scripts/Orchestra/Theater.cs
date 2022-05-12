using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Shell;
using UnityEngine;

namespace SilentOrchestra.Orchestra
{
    [System.Serializable]
    public class Theater 
    {
        public List<Government> Governments { get; private set; }= new List<Government>();

        public Theater(int governmentAmount)
        {
            GenerateGovernments(governmentAmount);
        }

        public void GenerateGovernments(int amount)
        {
            Governments = new List<Government>();
            for (int i = 0; i < amount; i++)
            {
                Government gov = new Government(GameSettings.AgenciesPerGovernment);
                Governments.Add(gov);
            }
        }
    }
}
