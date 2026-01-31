using GameProject.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;
namespace GameProject.Runtime.UI
{
    public class InventorySlotUI : MonoBehaviour
    {
        [Header("UI Components")]
        [SerializeField] private Image m_IconImage;
        [SerializeField] private Image m_BorderImage;

        [Header("Colors")]
        [SerializeField] private Color m_SelectedColor = Color.yellow;
        [SerializeField] private Color m_DefaultColor = Color.white;

        public void UpdateSlot(ItemData item, bool isSelected)
        {
            if (item != null)
            {
                m_IconImage.sprite = item.Icon;
                m_IconImage.enabled = true;
            }

            else
            {
                m_IconImage.sprite = null;
                m_IconImage.enabled = false;
            }

            m_BorderImage.color = isSelected ? m_SelectedColor : m_DefaultColor;
        }
    }
}
