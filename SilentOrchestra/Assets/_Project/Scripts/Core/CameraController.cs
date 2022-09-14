using System.Collections;
using System.Collections.Generic;
using SilentOrchestra.Shell;
using UnityEngine;

namespace SilentOrchestra.Core
{
    public class CameraController : MonoBehaviour
    {
        #region Serialized Fields
        [Header("References")] 
        [SerializeField] private Transform cameraTransform;
        
        [Header("Settings")]
        [SerializeField] private float normalMoveSpeed = 0.5f;
        [SerializeField] private float fastMoveSpeed = 3f;
        [SerializeField] private float rotationSpeed = 0.5f;
        [SerializeField] private float zoomSpeed = 5f;
        [SerializeField] private float transitionLerpSpeed = 5f;
        #endregion

        #region PRivate Fields
        private float _movementSpeed = 1f;
        private Vector3 _targetPosition;
        private Quaternion _targetRotation;
        private Vector3 _targetZoomPosition;
        #endregion
        
        private void Start()
        {
            _targetPosition = transform.position;
            _targetRotation = transform.rotation;
            _targetZoomPosition = cameraTransform.localPosition;
            
            _movementSpeed = normalMoveSpeed;

            ShellAnchor.Input.BindMainStartedAction("SpeedMove", () => _movementSpeed = fastMoveSpeed);
            ShellAnchor.Input.BindMainCancelledAction("SpeedMove", () => _movementSpeed = normalMoveSpeed);
        }
        
        private void Update()
        {
            HandleCameraMovement();
        }

        private void HandleCameraMovement()
        {
            var moveInput = ShellAnchor.Input.MovementInput;
            _targetPosition += (transform.forward * moveInput.y + transform.right * moveInput.x) * _movementSpeed;
            _targetRotation *= Quaternion.Euler(Vector3.up * (ShellAnchor.Input.RotationInput * rotationSpeed));
            _targetZoomPosition += cameraTransform.forward * (ShellAnchor.Input.ZoomInput * zoomSpeed);
            
            transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * transitionLerpSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Time.deltaTime * transitionLerpSpeed);
            cameraTransform.localPosition = Vector3.Lerp(   cameraTransform.localPosition, _targetZoomPosition, Time.deltaTime * transitionLerpSpeed);
        }
    }
}