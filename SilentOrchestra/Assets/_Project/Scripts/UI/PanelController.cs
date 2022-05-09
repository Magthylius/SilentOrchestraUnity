using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.UI
{
    [RequireComponent(typeof(Canvas))]
    public class PanelController : MonoBehaviour
    {
        [SerializeField] private PanelWindow[] panels;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            foreach (PanelWindow panel in panels)
            {
                panel.Initialize(this);
            }
        }
    }
}
