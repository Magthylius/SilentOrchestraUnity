using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.UI
{
    [RequireComponent(typeof(Canvas))]
    public class PanelController : MonoBehaviour
    {
        [SerializeField] private PanelWindow[] windows;

        protected MenuController Menu;

        public void Initialize(MenuController menu)
        {
            Menu = menu;
            foreach (PanelWindow window in windows)
            {
                window.Initialize(this);
            }
        }
    }
}
