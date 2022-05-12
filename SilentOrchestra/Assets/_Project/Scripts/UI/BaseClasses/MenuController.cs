using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.UI
{
    public class MenuController : MonoBehaviour
    {
        #region Serialized Fields
        [Header("References")]
        [SerializeField] private PanelController[] panels;

        [Header("Settings")] 
        [SerializeField] private bool initializeOnStart = true;
        #endregion

        protected virtual void Start()
        {
            if (initializeOnStart) Initialize();
        }

        public virtual void Initialize()
        {
            foreach (PanelController panel in panels)
            {
                panel.Initialize(this);
            }
        }
    }
}
