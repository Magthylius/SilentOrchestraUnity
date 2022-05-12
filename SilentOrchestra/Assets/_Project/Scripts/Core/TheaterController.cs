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
        #region Private Fields
        private Theater _currentTheater;
        #endregion

        private void Start()
        {
            CreateNewTheater();
        }

        public override void Initialize(CoreSystem coreSystem)
        {
            base.Initialize(coreSystem);
        }

        public void CreateNewTheater()
        {
            _currentTheater = new Theater(GameSettings.GovernmentsPerTheater);
        }
    }
}
