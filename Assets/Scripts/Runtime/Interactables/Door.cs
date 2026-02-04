using GameProject.Runtime.Core;
using GameProject.Runtime.Player;
using GameProject.Runtime.Data;
using UnityEngine;
using GameProject.Runtime.Audio;

namespace GameProject.Runtime.Interactables
{
    /// <summary>
    /// Door interactable object.
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class Door : MonoBehaviour, IInteractable
    {
        #region Fields
        [Header("UI Prompt")]

        [SerializeField] private string m_PromptOpen = "Open Door";
        [SerializeField] private string m_PromptClose = "Close Door";
        [SerializeField] private string m_PromptLocked = "Locked (Req. Key)";
        [Header("Door Status")]
        [SerializeField] private bool m_IsLocked = false;
        [SerializeField] private bool m_IsOpen = false;
        [SerializeField] private string m_RequiredKeyID;
        [SerializeField] private float m_UnlockDuration = 2f;
        [Header("Animation Settings")]
        [SerializeField] private Animator m_Animator;
        private static readonly int s_OpenTrigger = Animator.StringToHash("Open");
        private static readonly int s_CloseTrigger = Animator.StringToHash("Close");
        [Header("Audio")]
        [SerializeField] private AudioClip m_OpenSFX;
        [SerializeField] private AudioClip m_CloseSFX;
        [SerializeField] private AudioClip m_UnlockSFX;
        #endregion
        #region Unity Methods
        private void Awake()
        {
            if (m_Animator == null)
            {
                m_Animator = GetComponent<Animator>();
            }
        }
        #endregion


        #region Public Methods
        /// <summary>
        /// When you interact with the lever, the door will open.
        /// </summary>
        public void ToggleDoor()
        {
            if (m_IsLocked)
            {
                return;
            }

            m_IsOpen = !m_IsOpen;

            if (m_IsOpen)//door is close
            {
                Debug.Log("Door is opening");
                m_Animator.SetTrigger(s_OpenTrigger);
                AudioManager.Instance.PlaySFX(m_OpenSFX);
            }
            else//door is open
            {
                Debug.Log("Door is closing");
                m_Animator.SetTrigger(s_CloseTrigger);
                AudioManager.Instance.PlaySFX(m_UnlockSFX);
            }
        }
        #endregion

        #region Interface Methods
        void IInteractable.Interact(InventoryManager inventory)
        {
            if (m_IsLocked)
            {

                if (inventory == null)
                {
                    Debug.LogWarning("Inventory is null");
                    return;
                }

                ItemData currentItem = inventory.GetSelectedItem();

                if (currentItem != null && currentItem.ID == m_RequiredKeyID)
                {
                    m_IsLocked = false;
                    inventory.RemoveSelectedItem();
                    Debug.Log("Interact(): Door unlocked");
                    AudioManager.Instance.PlaySFX(m_CloseSFX);
                }
                else
                {
                    Debug.Log($"Locked! Requires key: {m_RequiredKeyID}");
                }

                return;
            }

            ToggleDoor();

        }
        string IInteractable.GetInteractionPrompt()
        {
            if (m_IsLocked)
            {
                return m_PromptLocked;
            }
            return m_IsOpen ? m_PromptClose : m_PromptOpen;
        }

        float IInteractable.GetHoldDuration()
        {
            return m_IsLocked ? m_UnlockDuration : 0f;
        }
        #endregion
    }
}