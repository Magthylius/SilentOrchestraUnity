using System;
using System.Collections;
using System.Collections.Generic;
using Magthylius;
using UnityEngine;

namespace SilentOrchestra.Core
{
    using SilentOrchestra.Shell;
    using SilentOrchestra.World;
    
    public class CoreSystem : SoftSingleton<CoreSystem>
    {
        #region Serialized Fields
        [SerializeField] private ProjectConfig projectConfig;
        [SerializeField] private TimeController timeController;
        [SerializeField] private TheaterController theaterController;
        #endregion
        
        private void Start()
        {
            projectConfig.OverrideGameSettings();
            timeController.Initialize(this, DateTime.Now);
            theaterController.Initialize(this);
            
            WorldAnchor.Generator.Initialize();
        }

        public TheaterController Theater => theaterController;
    }

}