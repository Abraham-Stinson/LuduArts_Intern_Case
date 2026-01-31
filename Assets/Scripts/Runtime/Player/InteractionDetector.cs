using GameProject.Runtime.Core;
using GameProject.Runtime.UI;
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
        private float m_CurrentHoldTimer = 0f;

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
        }
        private void OnDisable()
        {
            if (m_InteractInputReference != null)
            {
                m_InteractInputReference.action.Disable();
            }
        }
        private void Update()
        {
            CheckForInteractable();
            HandleInteractionInput();
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
                    UIManager.Instance.SetPromptText(interactable.GetInteractionPrompt());
                    return;
                }
            }
            m_CurrentInteractable = null;
            UIManager.Instance.HidePrompt();
        }

        private void HandleInteractionInput()
        {
            if (m_CurrentInteractable == null)
            {
                m_CurrentHoldTimer = 0f;
                UIManager.Instance.HideProgressBar();
                return;
            }

            bool isPressed = m_InteractInputReference.action.IsPressed();

            if (isPressed)
            {
                float requiredTime = m_CurrentInteractable.GetHoldDuration();

                if (requiredTime <= 0f)
                {
                    if (m_InteractInputReference.action.WasPressedThisFrame())
                    {
                        m_CurrentInteractable.Interact();
                    }
                }
                else
                {
                    m_CurrentHoldTimer += Time.deltaTime;

                    float progress = Mathf.Clamp01(m_CurrentHoldTimer / requiredTime);
                    Debug.Log($"Holding... %{progress * 100:F0}");

                    UIManager.Instance.UpdateProgressBar(progress);
                    if (m_CurrentHoldTimer >= requiredTime)
                    {
                        m_CurrentInteractable.Interact();
                        m_CurrentHoldTimer = 0f;
                        UIManager.Instance.HideProgressBar();
                    }
                }
            }
            else
            {
                m_CurrentHoldTimer = 0f;
                UIManager.Instance.HideProgressBar();
            }
        }
        #endregion
    }
}