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
        #region Serialized Fields
        [Header("References")]
        [SerializeField] private TextMeshProUGUI agencyTitleLabel;
        [SerializeField] private TextMeshProUGUI agencySizeLabel;
        [SerializeField] private AgentListController agentListController;

        [Header("Settings")] 
        [SerializeField] private string agencySizePrefix = "Agents:";
        #endregion

        #region Private Fields
        private TheaterController _theaterController;
        private Agency _playerAgency;
        #endregion

        public override void Initialize()
        {
            base.Initialize();
            agentListController.Initialize();
            
            _theaterController = CoreSystem.Instance.Theater;
            
            _theaterController.OnTheaterCreated += OnTheaterCreated;
        }

        private void OnDestroy()
        {
            _theaterController.OnTheaterCreated -= OnTheaterCreated;
        }

        #region Delegates
        private void OnTheaterCreated(Theater theater)
        {
            _playerAgency = _theaterController.PlayerAgency;
            agencyTitleLabel.text = _playerAgency.Name;
            agencySizeLabel.text = $"{agencySizePrefix.Trim()} {_playerAgency.AgentCount.ToString()}";
        }
        #endregion
    }
}
