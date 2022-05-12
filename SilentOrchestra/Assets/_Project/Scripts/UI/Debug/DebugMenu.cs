using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Core;
using UnityEngine;

namespace SilentOrchestra.UI
{
    public class DebugMenu : MenuController
    {
        private TheaterController _theaterController;

        public override void Initialize()
        {
            base.Initialize();
            _theaterController = CoreSystem.Instance.Theater;
        }
    }
}
