using System;
using SilentOrchestra.Shell;

namespace SilentOrchestra.Orchestra
{
    [Serializable]
    public class Agent
    {
        public string name;
        public AgentInfo Info;
        public AgentStats Stats;

        public Action<Agent, float> OperationContributed;

        public Agent(AgentInfo info, AgentStats stats)
        {
            name = info.codename;
            Info = info;
            Stats = stats;
        }
        
        public void Tick() { }

        public static Agent RandomAgent
        {
            get
            {
                AgentInfo info = new AgentInfo();
                AgentStats stats = AgentStats.Randomized;

                info.codename = DatabaseFactory.RandomCodename;
                info.agentID = DatabaseFactory.RandomID;
                info.realPersona = PersonaInfo.Randomized;
                info.undercoverPersona = PersonaInfo.Randomized;

                return new Agent(info, stats);
            }
        }
    }
    
}
