using UnityEngine;
using UnityEngine.Events;
using GameProject.Runtime.Core;

namespace GameProject.Runtime.Interactables
{
    /// <summary>
    /// Event-based toggle switch/lever. Can trigger multiple objects.
    /// </summary>
    public class Lever : MonoBehaviour, IInteractable
    {
        #region Fields
        [Header("Lever Status")]
        [SerializeField] private bool m_IsSwitchOn = false;

        [Header("UI Prompts")]
        [SerializeField] private string m_PromptSwitchOn = "Switch On";
        [SerializeField] private string m_PromptSwitchOff = "Switch Off";
        [Header("Unity Events")]
        [SerializeField] private UnityEvent m_OnLeverActivated;
        [SerializeField] private UnityEvent m_OnLeverDeactivated;

        private Animator m_Animator;
        private static readonly int ActiveTrigger = Animator.StringToHash("Active");
        private static readonly int DeactiveTrigger = Animator.StringToHash("Deactive");

        #endregion

        #region Unity Methods
        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
        }
        #endregion

        #region Interface Methods
        public void Interact()
        {
            m_IsSwitchOn = !m_IsSwitchOn;

            if (m_IsSwitchOn)//Switch on
            {
                m_Animator.SetTrigger(ActiveTrigger);
                m_OnLeverActivated?.Invoke();
            }
            else //Switch off
            {
                m_Animator.SetTrigger(DeactiveTrigger);
                m_OnLeverDeactivated?.Invoke();
            }
            
        }
        
        public string GetInteractionPrompt()
        {
            return m_IsSwitchOn ? m_PromptSwitchOn : m_PromptSwitchOff;
        }
        #endregion
    }
}

