using UnityEngine;
using UnityEngine.Events;
using GameProject.Runtime.Core;
using GameProject.Runtime.Player;
using GameProject.Runtime.Audio;

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
        private static readonly int s_ActiveTrigger = Animator.StringToHash("Active");
        private static readonly int s_DeactiveTrigger = Animator.StringToHash("Deactive");
        [Header("Audio")]
        [SerializeField] private AudioClip m_SwitchOn;
        [SerializeField] private AudioClip m_SwitchOff;

        #endregion

        #region Unity Methods
        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
        }
        #endregion

        #region Interface Methods
        void IInteractable.Interact(InventoryManager inventory)
        {
            m_IsSwitchOn = !m_IsSwitchOn;

            if (m_IsSwitchOn)//Switch on
            {
                m_Animator.SetTrigger(s_ActiveTrigger);
                m_OnLeverActivated?.Invoke();
                AudioManager.Instance.PlaySFX(m_SwitchOn);
            }
            else //Switch off
            {
                m_Animator.SetTrigger(s_DeactiveTrigger);
                m_OnLeverDeactivated?.Invoke();
                AudioManager.Instance.PlaySFX(m_SwitchOff);
            }

        }

        string IInteractable.GetInteractionPrompt()
        {
            return m_IsSwitchOn ? m_PromptSwitchOn : m_PromptSwitchOff;
        }

        float IInteractable.GetHoldDuration() => 0f;
        #endregion
    }
}

