using System.Collections;
using System.Collections.Generic;
using Magthylius;
using UnityEngine;

namespace SilentOrchestra.Shell
{
    public class ShellAnchor : HardSingleton<ShellAnchor>
    {
        [SerializeField] private InputHandler inputHandler;

        public static InputHandler Input => Instance.inputHandler;
    }
}
