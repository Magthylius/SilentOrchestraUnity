using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Shell;
using UnityEngine;

namespace SilentOrchestra.Theaters
{
    public class Government 
    {
        private List<Agency> _agencies = new List<Agency>();

        public Government(int agencyAmount)
        {
            GenerateAgencies(agencyAmount);
        }
        
        public void GenerateAgencies(int amount)
        {
            _agencies = new List<Agency>();
            for (int i = 0; i < amount; i++)
            {
                Agency agency = new Agency(GameSettings.AgentsPerAgency);
                _agencies.Add(agency);
            }
        }
    }
}
