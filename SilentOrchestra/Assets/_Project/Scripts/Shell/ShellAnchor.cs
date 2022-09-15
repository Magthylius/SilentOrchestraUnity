using Magthylius;
using UnityEngine;

namespace SilentOrchestra.Shell
{
    public class ShellAnchor : HardSingleton<ShellAnchor>
    {
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private CameraController cameraController;

        public static InputHandler Input => Instance.inputHandler;
        public static CameraController Camera => Instance.cameraController;
    }
}
