using GameProject.Runtime.Core;
using GameProject.Runtime.Player;
using GameProject.Runtime.Data;
using UnityEngine;
namespace GameProject.Runtime.Interactables
{
    public class Chest : MonoBehaviour, IInteractable
    {
        #region Fields
        [Header("Chest Settings")]
        [SerializeField] private string m_PromptMessageToOpen = "Open Chest";
        [SerializeField] private float m_HoldInteractDuration = 2f;
        [SerializeField] private bool m_IsOpened = false;

        [Header("Giving Item")]
        [SerializeField] private ItemData m_ItemToGive;

        private Animator m_Animator;
        private static readonly int s_OpenTrigger = Animator.StringToHash("Open");
        #endregion

        #region Unity Methods
        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
        }
        #endregion



        #region Methods
        private void OpenChest()
        {
            m_IsOpened = true;
            m_Animator.SetTrigger(s_OpenTrigger);

            if (m_ItemToGive != null)
            {
                InventoryManager inventory = FindObjectOfType<InventoryManager>();
                if (inventory != null)
                {
                    inventory.AddItem(m_ItemToGive);
                }
            }
        }
        #endregion

        #region Interface Methods
        void IInteractable.Interact()
        {
            if (m_IsOpened)
            {
                return;
            }

            OpenChest();
        }
        string IInteractable.GetInteractionPrompt()
        {
            return m_IsOpened ? "Empty" : m_PromptMessageToOpen;
        }

        float IInteractable.GetHoldDuration()
        {
            return m_IsOpened ? 0f : m_HoldInteractDuration;
        }
        #endregion
    }
}

