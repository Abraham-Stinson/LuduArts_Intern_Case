using UnityEngine;
using GameProject.Runtime.Core;
using GameProject.Runtime.Player;
using GameProject.ScriptableObjects;

namespace GameProject.Runtime.Interactables
{
    public class Key : MonoBehaviour, IInteractable
    {
        #region Fields
        [SerializeField] private ItemData m_ItemData;
        #endregion

        #region Unity Methods
        #endregion

        #region public Methods for Interactable
        public void Interact()
        {
            InventoryManager inventory = FindObjectOfType<InventoryManager>();

            if (inventory != null)
            {
                bool isAdded = inventory.AddItem(m_ItemData);

                if (isAdded)
                {
                    Destroy(gameObject);
                }
            }
        }

        public string GetInteractionPrompt()
        {
            return $"Pick up {m_ItemData.ItemName}";
        }
        #endregion
    }

}

