using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilentOrchestra.Core
{
    public class TimeController : SystemController
    {
        #region Private Fields
        private DateTime _currentDateTime;
        #endregion

        public void Initialize(CoreSystem coreSystem, DateTime startingTime)
        {
            base.Initialize(coreSystem);
            _currentDateTime = startingTime;
        }
    }

}