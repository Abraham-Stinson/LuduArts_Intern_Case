using System;
using UnityEngine;

namespace GameProject.Runtime
{
    /// <summary>
    /// Class that manages player movement and camera rotation.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Fields
        [Header("Movement")]
        [SerializeField] private CharacterController m_CharacterController;
        [SerializeField, Range(0f, 20f)] private float m_PlayerMovementSpeed = 10f;
        [Header("Camera and Rotation")]
        [SerializeField] private Transform m_CameraTransform;
        [SerializeField, Range(0f, 100f)] private float m_MouseSensitivity = 10f;
        [SerializeField, Range(45f, 135f)] private float m_MaxRotateAngle = 90f;
        [SerializeField, Range(-135f, -45f)] private float m_MinRotateAngle = -90f;
        private float m_xRotation;
        [Header("Player Input Action")]
        [SerializeField] private InputSystem_Actions m_PlayerInputAction;
        #endregion
        #region Unity Methods
        private void Awake()
        {
            m_PlayerInputAction = new InputSystem_Actions();
        }
        private void OnEnable()
        {
            m_PlayerInputAction.Enable();
        }
        private void OnDisable()
        {
            m_PlayerInputAction.Disable();
        }
        private void Update()
        {
            HandleMovement();
        }

        private void LateUpdate()
        {
            HandleRotate();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Calculates and implements the character's walking operations.
        /// </summary>
        private void HandleMovement()//Movement
        {
            Vector2 moveInput = m_PlayerInputAction.Player.Move.ReadValue<Vector2>();
            Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;
            m_CharacterController.Move(moveDirection * m_PlayerMovementSpeed * Time.deltaTime);
            Debug.Log($"HandleMovement(): moveDirection: {moveDirection}");
        }

        /// <summary>
        /// Calculates camera and character rotation based on mouse input.
        /// </summary>
        private void HandleRotate()//Rotate
        {
            Vector2 lookInput = m_PlayerInputAction.Player.Look.ReadValue<Vector2>();
            float mouseX = lookInput.x * m_MouseSensitivity * Time.deltaTime;
            transform.Rotate(Vector3.up * mouseX);

            float mouseY = lookInput.y * m_MouseSensitivity * Time.deltaTime;
            m_xRotation -= mouseY;

            m_xRotation = Mathf.Clamp(m_xRotation, m_MinRotateAngle, m_MaxRotateAngle);

            m_CameraTransform.localRotation = Quaternion.Euler(m_xRotation, 0f, 0f);
        }
        #endregion

    }
}
