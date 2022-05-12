using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Core;
using UnityEngine;

namespace SilentOrchestra.UI
{
    public class DebugMenu : MenuController
    {
        private readonly CoreSystem _core = CoreSystem.Instance;
        private TheaterController _theaterController;

        public override void Initialize()
        {
            base.Initialize();
            _theaterController = _core.Theater;
        }
    }
}
