using System;
using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Shell;
using SilentOrchestra.Orchestra;
using UnityEngine;

namespace SilentOrchestra.Core
{
    public class TheaterController : SystemController
    {
        #region Serialized Fields
        
        #endregion
        
        #region Public Fields
        public List<Government> AllGovernments { get; private set; } = new List<Government>();
        public List<Agency> AllAgencies { get; private set; } = new List<Agency>();
        public List<Agent> AllAgents { get; private set; } = new List<Agent>();
        public Action<Theater> OnTheaterCreated;
        #endregion
        
        #region Private Fields
        private Theater _currentTheater;
        #endregion
        
        public override void Initialize(CoreSystem coreSystem)
        {
            base.Initialize(coreSystem);
            CreateNewTheater();
        }

        public void CreateNewTheater()
        {
            _currentTheater = new Theater(GameSettings.GovernmentsPerTheater);

            AllGovernments = new List<Government>(_currentTheater.Governments);
            AllAgencies = new List<Agency>();
            AllAgents = new List<Agent>();
            
            foreach (Government government in AllGovernments) AllAgencies.AddRange(government.Agencies);
            foreach (Agency agency in AllAgencies) AllAgents.AddRange(agency.Agents);
            
            OnTheaterCreated?.Invoke(_currentTheater);
        }
    }
}
