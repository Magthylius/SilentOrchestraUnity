using System;
using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Core;
using SilentOrchestra.Orchestra;
using TMPro;
using UnityEngine;

namespace SilentOrchestra.UI
{
    public class AgencyMenu : MenuController
    {
        [SerializeField] private TextMeshProUGUI agencyTitleLabel;
        [SerializeField] private TextMeshProUGUI agencySizeLabel;
        [SerializeField] private AgentListController agentListController;

        #region Private Fields
        private readonly CoreSystem _core = CoreSystem.Instance;
        private readonly TheaterController _theaterController =  CoreSystem.Instance.Theater;
        #endregion

        public override void Initialize()
        {
            base.Initialize();
            agentListController.Initialize();

            _theaterController.OnTheaterCreated += OnTheaterCreated;
        }

        private void OnDestroy()
        {
            _theaterController.OnTheaterCreated -= OnTheaterCreated;
        }

        public void SetDetails(string agencyName)
        {
            agencyTitleLabel.text = agencyName;
        }

        #region Delegates
        private void OnTheaterCreated(Theater theater)
        {
            
        }
        #endregion
    }
}
