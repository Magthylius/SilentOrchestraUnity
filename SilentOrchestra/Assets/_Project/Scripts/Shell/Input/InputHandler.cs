using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SilentOrchestra.Shell
{
    public class InputHandler : MonoBehaviour
    {
        #region Serialized Fields
        [SerializeField] private InputActionAsset inputActionMap;
        #endregion

        #region Public Fields
        public readonly Dictionary<string, InputAction> MainMappings = new();
        #endregion

        #region Private Fields
        private InputAction _moveAction;
        private InputAction _rotateAction;
        private InputAction _zoomAction;
        private readonly Dictionary<(string inputName, InputActionPhase phase), Action> _mainActions = new();
        #endregion

        private void Awake()
        {
            _moveAction = inputActionMap.FindAction("Main/Move", true);
            _rotateAction = inputActionMap.FindAction("Main/Rotate", true);
            _zoomAction = inputActionMap.FindAction("Main/Zoom", true);
            SetupDictionaries("Main", MainMappings, _mainActions);
        }

        private void SetupDictionaries(string inputMapName, Dictionary<string, InputAction> mappingDict, Dictionary<(string inputName, InputActionPhase phase), Action> actionDict)
        {
            foreach (var action in inputActionMap.FindActionMap(inputMapName).actions)
            {
                mappingDict.Add(action.name, action);
                actionDict.Add((action.name, InputActionPhase.Started), null);
                actionDict.Add((action.name, InputActionPhase.Performed), null);
                actionDict.Add((action.name, InputActionPhase.Canceled), null);
                
                action.started += context => actionDict[(action.name, InputActionPhase.Started)]?.Invoke();
                action.performed += context => actionDict[(action.name, InputActionPhase.Performed)]?.Invoke();
                action.canceled += context => actionDict[(action.name, InputActionPhase.Canceled)]?.Invoke();
            }
        }
        
        /// <summary>Binds an action into an input on <see cref="InputAction.performed"/> phase.</summary>
        private void AddActionBind(Dictionary<(string inputName, InputActionPhase phase), Action> targetActions, string inputName, InputActionPhase phase, Action actionBind)
        {
            if (targetActions.ContainsKey((inputName, phase))) targetActions[(inputName, phase)] += actionBind;
            else Debug.LogWarning($"Input {inputName} not found");
        }
        public void BindMainStartedAction(string inputName, Action actionBind) => AddActionBind(_mainActions, inputName, InputActionPhase.Started, actionBind);
        public void BindMainPerformedAction(string inputName, Action actionBind) => AddActionBind(_mainActions, inputName, InputActionPhase.Performed, actionBind);
        public void BindMainCancelledAction(string inputName, Action actionBind) => AddActionBind(_mainActions, inputName, InputActionPhase.Canceled, actionBind);
        
        /// <summary>Removes a bound action from an input on <see cref="InputAction.performed"/> phase.</summary>
        private void RemoveActionBind(Dictionary<(string inputName, InputActionPhase phase), Action> targetActions, string inputName, InputActionPhase phase, Action actionBind)
        {
            if (targetActions.ContainsKey((inputName, phase))) targetActions[(inputName, phase)] -= actionBind;
            else Debug.LogWarning($"Input {inputName} not found");
        }
        public void RemoveCameraPerformedBind(string inputName, Action actionBind) => RemoveActionBind(_mainActions, inputName, InputActionPhase.Performed, actionBind);

        public Vector2 MovementInput => _moveAction.ReadValue<Vector2>();
        public float RotationInput => _rotateAction.ReadValue<float>();
        public float ZoomInput => _zoomAction.ReadValue<float>();
    }
}
