using GameProject.Runtime.Core;
using GameProject.Runtime.Player;
using GameProject.ScriptableObjects;
using Unity.VisualScripting;
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
        private static readonly int OpenTrigger = Animator.StringToHash("Open");
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
            if (m_IsOpened)
            {
                return;
            }

            OpenChest();
        }
        public string GetInteractionPrompt()
        {
            return m_IsOpened ? "Empty" : m_PromptMessageToOpen;
        }

        public float GetHoldDuration()
        {
            return m_IsOpened ? 0f : m_HoldInteractDuration;
        }
        #endregion

        #region Methods
        private void OpenChest()
        {
            m_IsOpened=true;
            m_Animator.SetTrigger(OpenTrigger);

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
    }
}

