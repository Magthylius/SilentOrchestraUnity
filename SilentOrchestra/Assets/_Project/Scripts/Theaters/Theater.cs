using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Shell;
using UnityEngine;

namespace SilentOrchestra.Theaters
{
    public class Theater 
    {
        private List<Government> _governments = new List<Government>();

        public Theater(int governmentAmount)
        {
            GenerateGovernments(governmentAmount);
        }

        public void GenerateGovernments(int amount)
        {
            _governments = new List<Government>();
            for (int i = 0; i < amount; i++)
            {
                Government gov = new Government(GameSettings.AgenciesPerGovernment);
                _governments.Add(gov);
            }
        }
    }
}
