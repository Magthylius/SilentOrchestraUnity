using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PanelWindow : MonoBehaviour
    {
        protected CanvasGroup CanvasGroup;
        protected PanelController Controller;

        private void OnEnable()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
        }

        public virtual void Initialize(PanelController controller)
        {
            Controller = controller;
        }

        public virtual void SetPanelState(bool show)
        {
            CanvasGroup.alpha = show ? 1f : 0f;
            CanvasGroup.interactable = show;
            CanvasGroup.blocksRaycasts = show;
        }

        public void ShowPanel() => SetPanelState(true);
        public void HidePanel() => SetPanelState(false);
    }
}
