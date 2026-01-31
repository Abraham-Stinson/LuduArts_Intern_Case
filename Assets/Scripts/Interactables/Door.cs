using GameProject.Runtime.Core;
using UnityEngine;

namespace GameProject.Runtime.Interactables
{
    /// <summary>
    /// Door interactable object.
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class Door : MonoBehaviour, IInteractable
    {
        #region Field
        [Header("UI Prompt")]
        private string m_UIPromptMessage;
        [SerializeField] private string m_PromptOpen = "Open Door";
        [SerializeField] private string m_PromptClose = "Close Door";
        [SerializeField] private string m_PromptLocked = "Locked (Req. Key)";
        [Header("Door Status")]
        [SerializeField] private bool m_IsLocked = false;
        [SerializeField] private bool m_IsOpen = false;
        [Header("Animation Settings")]
        [SerializeField] private Animator m_Animator;
        private static readonly int OpenTrigger = Animator.StringToHash("Open");
        private static readonly int CloseTrigger = Animator.StringToHash("Close");
        #endregion

        #region Methods
        public void Interact()
        {
            if (m_IsLocked)
            {
                m_UIPromptMessage = m_PromptLocked;
                //TODO: When a key object is added the unlock event will be added
                return;
            }

            m_IsOpen = !m_IsOpen;

            if (m_IsOpen)//door is close
            {
                Debug.Log("Door is opening");
                m_Animator.SetTrigger(OpenTrigger);
            }
            else//door is open
            {
                Debug.Log("Door is closing");
                m_Animator.SetTrigger(CloseTrigger);
            }

        }
        public string GetInteractionPrompt()
        {
            if (m_IsLocked)
            {
                return m_PromptLocked;
            }
            return m_IsOpen ? m_PromptClose : m_PromptOpen;
        }
        #endregion
    }
}