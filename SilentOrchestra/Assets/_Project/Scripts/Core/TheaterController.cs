using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Shell;
using SilentOrchestra.Theaters;
using UnityEngine;

namespace SilentOrchestra.Core
{
    public class TheaterController : SystemController
    {
        #region Private Fields
        private Theater _currentTheater;
        #endregion
        
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
