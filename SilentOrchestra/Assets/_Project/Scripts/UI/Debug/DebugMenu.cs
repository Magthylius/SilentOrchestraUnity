using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Core;
using UnityEngine;

namespace SilentOrchestra.UI
{
    public class DebugMenu : MenuController
    {
        private CoreSystem _core;
        private TheaterController _theaterController;

        public override void Initialize()
        {
            base.Initialize();
            _core = CoreSystem.Instance;
            _theaterController = _core.Theater;
        }
    }
}
