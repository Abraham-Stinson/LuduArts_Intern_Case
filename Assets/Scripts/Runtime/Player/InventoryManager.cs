using System.Collections.Generic;
using GameProject.Runtime.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using GameProject.Runtime.UI;
using GameProject.Runtime.Data;
using System;

namespace GameProject.Runtime.Player
{
    /// <summary>
    /// Manages the player's inventory, items in hand, and slot selection.
    /// </summary>
    public class InventoryManager : MonoBehaviour
    {
        #region Fields
        [Header("Inventory")]
        [SerializeField] private int m_MaxSlot = 4;
        [SerializeField] private Transform m_HandPosition;
        [SerializeField] private Transform m_DropPosition;

        [Header("Input")]
        [SerializeField] private InputActionReference m_ScrollInput;
        [SerializeField] private InputActionReference m_DropInput;

        [Header("UI References")]
        [SerializeField] private InventoryUI m_InventoryUI;

        //Inventory
        private List<ItemData> m_InventorySlots = new List<ItemData>();
        private int m_CurrentInventorySlotIndex = 0;
        private GameObject m_CurrentlyInHandObject;
        #endregion

        #region Unity Methods
        private void Start()
        {
            if (m_InventoryUI != null)
            {
                m_InventoryUI.UpdateUI(m_InventorySlots, m_CurrentInventorySlotIndex);
            }

        }
        private void OnEnable()
        {
            m_ScrollInput.action.Enable();
            m_DropInput.action.Enable();

            m_ScrollInput.action.performed += HandleScroll;
            m_DropInput.action.performed += HandleDrop;

        }
        private void OnDisable()
        {
            m_ScrollInput.action.performed -= HandleScroll;
            m_DropInput.action.performed -= HandleDrop;

            m_ScrollInput.action.Disable();
            m_DropInput.action.Disable();
        }
        #endregion

        #region Public Methods for Interaction System

        /// <summary>
        /// Add items to inventory
        /// </summary>
        public bool AddItem(ItemData item)
        {
            if (m_InventorySlots.Count >= m_MaxSlot)
            {
                Debug.LogWarning("Slots full");
                return false;
            }

            m_InventorySlots.Add(item);

            if (m_InventoryUI != null)
            {
                m_InventoryUI.UpdateUI(m_InventorySlots, m_CurrentInventorySlotIndex);
            }

            //Change visual of item
            if (m_InventorySlots.Count - 1 == m_CurrentInventorySlotIndex)
            {
                UpdateHandVisualItem();
            }
            Debug.Log($"AddItem: {item.ItemName}");
            return true;
        }
        /// <summary>
        /// This method returns selected item 
        /// </summary>
        public ItemData GetSelectedItem()
        {
            if (m_InventorySlots.Count == 0 || m_CurrentInventorySlotIndex >= m_InventorySlots.Count)
            {
                return null;
            }
            return m_InventorySlots[m_CurrentInventorySlotIndex];
        }
        ///<summary>
        /// Remove item that selected
        /// </summary>
        public void RemoveSelectedItem()
        {
            if (GetSelectedItem() != null)
            {
                m_InventorySlots.RemoveAt(m_CurrentInventorySlotIndex);

                if (m_CurrentInventorySlotIndex >= m_InventorySlots.Count)
                {
                    m_CurrentInventorySlotIndex = Mathf.Max(0, m_InventorySlots.Count - 1);
                }

                if (m_InventoryUI != null)
                {
                    m_InventoryUI.UpdateUI(m_InventorySlots, m_CurrentInventorySlotIndex);
                }

                UpdateHandVisualItem();
            }
        }
        #endregion
        #region private methods
        private void HandleScroll(InputAction.CallbackContext context)
        {
            if (m_InventorySlots.Count <= 1)
            {
                return;
            }
            float scrollValue = context.ReadValue<float>();

            if (scrollValue > 0)
            {
                m_CurrentInventorySlotIndex++;
                if (m_CurrentInventorySlotIndex >= m_InventorySlots.Count)
                {
                    m_CurrentInventorySlotIndex = 0;
                }
            }
            else if (scrollValue < 0)
            {
                m_CurrentInventorySlotIndex--;
                if (m_CurrentInventorySlotIndex < 0)
                {
                    m_CurrentInventorySlotIndex = m_InventorySlots.Count - 1;
                }
            }

            if (m_InventoryUI != null)
            {
                m_InventoryUI.UpdateUI(m_InventorySlots, m_CurrentInventorySlotIndex);
            }

            UpdateHandVisualItem();
            Debug.Log($"HandleScroll(): Selected slot: {m_CurrentInventorySlotIndex}");
        }

        private void HandleDrop(InputAction.CallbackContext context)
        {
            ItemData currentItem = GetSelectedItem();

            if (currentItem == null)
            {
                return;
            }

            if (currentItem.Prefab != null)
            {
                Instantiate(currentItem.Prefab, m_DropPosition.position, Quaternion.identity);
            }

            RemoveSelectedItem();
            Debug.Log($"Item dropped: {currentItem.ItemName}");
        }
        private void UpdateHandVisualItem()
        {
            if (m_CurrentlyInHandObject != null)
            {
                Destroy(m_CurrentlyInHandObject);
            }

            ItemData currentItem = GetSelectedItem();

            if (currentItem == null || currentItem.Prefab == null)
            {
                return;
            }

            m_CurrentlyInHandObject = Instantiate(currentItem.Prefab, m_HandPosition);

            if (m_CurrentlyInHandObject.GetComponent<Rigidbody>())
            {
                Rigidbody rb = m_CurrentlyInHandObject.GetComponent<Rigidbody>();
                rb.isKinematic = true;
            }
            if (m_CurrentlyInHandObject.GetComponent<Collider>())
            {
                Collider col = m_CurrentlyInHandObject.GetComponent<Collider>();
                col.enabled = false;
            }

        }

        #endregion
    }
}

