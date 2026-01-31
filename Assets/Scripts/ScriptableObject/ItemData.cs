using UnityEngine;
namespace GameProject.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewItem",menuName ="Game/Item Data")]
    public class ItemData : ScriptableObject
    {
        [Header("ID")]
        [SerializeField] private string m_ItemName;
        [SerializeField] private string m_ID;//For Door

        [Header("Visual")]
        [SerializeField] private Sprite m_Icon;
        [SerializeField] private GameObject m_Prefab;

        public string ItemName => m_ItemName;
        public string ID => m_ID;
        public Sprite Icon => m_Icon;
        public GameObject Prefab => m_Prefab;
    }
}

