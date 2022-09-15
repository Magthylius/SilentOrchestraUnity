using SilentOrchestra.Shell;
using UnityEngine;

namespace SilentOrchestra.Core
{
    public class CameraController : MonoBehaviour
    {
        #region Serialized Fields
        [Header("References")] 
        [SerializeField] private Camera mainCamera;

        [Header("Settings")]
        [SerializeField] private float transitionLerpSpeed = 5f;
        [SerializeField] private float normalMoveSpeed = 0.5f;
        [SerializeField] private float fastMoveSpeed = 3f;
        [SerializeField] private float rotationSpeed = 0.5f;
        [SerializeField] private float zoomSpeed = 5f;

        [Space(10f)] 
        [SerializeField] private float dragSensitivity = 1f;
        [SerializeField] private float pivotSensitivity = 0.03f;
        #endregion

        #region Private Fields
        private Transform _followTransform;
        
        private float _currentMovementSpeed = 1f;
        private Vector3 _targetPosition;
        private Quaternion _targetRotation;
        private Vector3 _targetZoomPosition;

        private MouseControlMode _mouseMode = MouseControlMode.Idle;
        private Vector3 _dragStartPosition;
        private Vector3 _dragCurrentPosition;
        
        private Vector3 _pivotStartPosition;
        private Vector3 _pivotCurrentPosition;
        #endregion
        
        private void Start()
        {
            _targetPosition = transform.position;
            _targetRotation = transform.rotation;
            _targetZoomPosition = CamTransform.localPosition;
            
            _currentMovementSpeed = normalMoveSpeed;

            ShellAnchor.Input.BindMainStartedAction("Escape", () => _followTransform = null);
            ShellAnchor.Input.BindMainStartedAction("SpeedMove", () => _currentMovementSpeed = fastMoveSpeed);
            ShellAnchor.Input.BindMainCancelledAction("SpeedMove", () => _currentMovementSpeed = normalMoveSpeed);
            ShellAnchor.Input.BindMainStartedAction("Drag", OnDragStart);
            ShellAnchor.Input.BindMainCancelledAction("Drag", SetMouseModeIdle);
            ShellAnchor.Input.BindMainStartedAction("Pivot", OnPivotStart);
            ShellAnchor.Input.BindMainCancelledAction("Pivot", SetMouseModeIdle);
        }
        
        private void Update()
        {
            if (_followTransform != null)
            {
                _targetPosition = _followTransform.position;
            }
            else
            {
                HandleMouseInput();
                HandleMovementInput();
            }

            HandleTransitions();
        }

        private void HandleMouseInput()
        {
            var mousePos = ShellAnchor.Input.MousePosition;
            switch (_mouseMode)
            {
                case MouseControlMode.Drag:
                    var plane = new Plane(Vector3.up, Vector3.zero);
                    var ray = mainCamera.ScreenPointToRay(mousePos);

                    if (plane.Raycast(ray, out var entry))
                    {
                        _dragCurrentPosition = ray.GetPoint(entry);
                        _targetPosition = transform.position + (_dragStartPosition - _dragCurrentPosition) * dragSensitivity;
                    }
                    break;
                
                case MouseControlMode.Pivot:
                    _pivotCurrentPosition = mousePos;
                    var difference = _pivotStartPosition - _pivotCurrentPosition;
                    _pivotStartPosition = _pivotCurrentPosition;
                    _targetRotation *= Quaternion.Euler(Vector3.up * (-difference.x * pivotSensitivity));
                    break;
            }
        }

        private void HandleMovementInput()
        {
            var moveInput = ShellAnchor.Input.MovementInput;
            _targetPosition += (transform.forward * moveInput.y + transform.right * moveInput.x) * _currentMovementSpeed;
            _targetRotation *= Quaternion.Euler(Vector3.up * (ShellAnchor.Input.RotationInput * rotationSpeed));
            _targetZoomPosition += CamTransform.forward * (ShellAnchor.Input.ZoomInput * zoomSpeed);
        }

        private void HandleTransitions()
        {
            transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * transitionLerpSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Time.deltaTime * transitionLerpSpeed);
            CamTransform.localPosition = Vector3.Lerp(CamTransform.localPosition, _targetZoomPosition, Time.deltaTime * transitionLerpSpeed);
        }

        private void OnDragStart()
        {
            var plane = new Plane(Vector3.up, Vector3.zero);
            var ray = mainCamera.ScreenPointToRay(ShellAnchor.Input.MousePosition);

            if (plane.Raycast(ray, out var entry))
            {
                _dragStartPosition = ray.GetPoint(entry);
                _mouseMode = MouseControlMode.Drag;
            }
        }
        
        private void OnPivotStart()
        {
            _mouseMode = MouseControlMode.Pivot;
            _pivotStartPosition = ShellAnchor.Input.MousePosition;
        }
        
        private void SetMouseModeIdle()
        {
            _mouseMode = MouseControlMode.Idle;
        }

        private Transform CamTransform => mainCamera.transform;

        #region Declarations
        private enum MouseControlMode
        {
            Idle,
            Drag,
            Pivot
        }
        #endregion
    }
}