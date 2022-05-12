using System;
using System.Collections;
using System.Collections.Generic;
using Magthylius;
using SilentOrchestra.Shell;
using UnityEngine;

namespace SilentOrchestra.Core
{
    public class CoreSystem : SoftSingleton<CoreSystem>
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

        public TheaterController Theater => theaterController;
    }

}