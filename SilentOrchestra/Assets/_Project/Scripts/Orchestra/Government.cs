using System.Collections;
using System.Linq;
using System.Collections.Generic;
using SilentOrchestra.Shell;

namespace SilentOrchestra.Orchestra
{
    [System.Serializable]
    public class Government 
    {
        public List<Agency> Agencies { get; private set; } = new List<Agency>();

        public Government(int agencyAmount)
        {
            GenerateAgencies(agencyAmount);
        }
        
        public void GenerateAgencies(int amount)
        {
            Agencies = new List<Agency>();
            for (int i = 0; i < amount; i++)
            {
                Agency agency = new Agency(GameSettings.AgentsPerAgency);
                Agencies.Add(agency);
            }
        }

        public bool HasAgency(Agency agency) => Agencies.Contains(agency);
        public bool HasAgency(string agencyName) => Agencies.Contains(Agencies.FirstOrDefault(agency => agency.Name == agencyName));
    }
}
