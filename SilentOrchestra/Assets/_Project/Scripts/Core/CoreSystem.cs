using System;
using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Shell;
using UnityEngine;

namespace SilentOrchestra.Core
{
    public class CoreSystem : MonoBehaviour
    {
        #region Serialized Fields
        [SerializeField] private TimeController timeController;
        [SerializeField] private TheaterController theaterController;
        #endregion
        
        void Start()
        {
            GameSettings.ResetToDefaultSettings();
            timeController.Initialize(this, DateTime.Now);
            theaterController.Initialize(this);
        }

        void Update()
        {
        
        }
    }

}