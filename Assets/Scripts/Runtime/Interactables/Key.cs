using UnityEngine;
using GameProject.Runtime.Core;
using GameProject.Runtime.Player;
using GameProject.Runtime.Data;

namespace GameProject.Runtime.Interactables
{
    public class Key : MonoBehaviour, IInteractable
    {
        #region Fields
        [SerializeField] private ItemData m_ItemData;
        #endregion

        #region Unity Methods
        #endregion

        #region  Interface Methods
        void IInteractable.Interact()
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

        string IInteractable.GetInteractionPrompt()
        {
            return $"Pick up {m_ItemData.ItemName}";
        }

        float IInteractable.GetHoldDuration() => 0f;
        #endregion
    }

}

