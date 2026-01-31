using System.Collections.Generic;
using UnityEngine;
using GameProject.ScriptableObjects;
namespace GameProject.Runtime.UI
{
    public class InventoryUI : MonoBehaviour
    {
        [Header("Slots")]
        [SerializeField] private List<InventorySlotUI> m_SlotUIList;

        public void UpdateUI(List<ItemData> inventoryItems, int selectedIndex)
        {
            for (int i = 0; i < m_SlotUIList.Count; i++)
            {
                ItemData item = (i < inventoryItems.Count) ? inventoryItems[i] : null;

                bool isSelected = (i == selectedIndex);

                m_SlotUIList[i].UpdateSlot(item, isSelected);
            }
        }
    }

}
