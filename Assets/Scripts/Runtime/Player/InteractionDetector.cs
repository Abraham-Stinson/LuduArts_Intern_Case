using GameProject.Runtime.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameProject.Runtime
{
    /// <summary>
    /// Class that manages player interactions.
    /// </summary>

    public class InteractionDetector : MonoBehaviour
    {
        #region Fields
        [Header("Interaction")]
        [SerializeField] private Transform m_CameraTransform;
        [SerializeField, Range(1f, 10f)] private float m_InteractionRange = 3f;
        [SerializeField] private LayerMask m_InteractableLayer;
        [SerializeField] private InputActionReference m_InteractInputReference;

        private IInteractable m_CurrentInteractable;
        #endregion
        #region Unity Methods
        private void OnEnable()
        {
            if (m_InteractInputReference == null)
            {
                Debug.LogError($"{name}: Interact Input Reference is missing. Please assign it in the Inspector.");
                return;
            }
            m_InteractInputReference.action.Enable();
            m_InteractInputReference.action.performed += OnInteract;
        }
        private void OnDisable()
        {
            if (m_InteractInputReference != null)
            {
                m_InteractInputReference.action.performed -= OnInteract;
                m_InteractInputReference.action.Disable();
            }
        }
        private void Update()
        {
            CheckForInteractable();
        }
        #endregion
        #region Methods
        private void CheckForInteractable()
        {
            Ray ray = new Ray(m_CameraTransform.position, m_CameraTransform.forward);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * m_InteractionRange, Color.red);

            if (Physics.Raycast(ray, out hit, m_InteractionRange, m_InteractableLayer))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    m_CurrentInteractable = interactable;
                    //TODO: UI MESSAGE WILL BE ADD
                    return;
                }
            }
            m_CurrentInteractable = null;
        }
        private void OnInteract(InputAction.CallbackContext context)
        {
            if (m_CurrentInteractable != null)
            {
                m_CurrentInteractable.Interact();
                Debug.Log($"OnInteract(): Interacted");
            }
        }
        #endregion
    }
}