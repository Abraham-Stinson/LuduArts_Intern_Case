using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace GameProject.Runtime.UI
{
    public class UIManager : MonoBehaviour
    {
        #region Singleton
        public static UIManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
        #endregion

        #region Field
        [Header("Prompt Message")]
        [SerializeField] private GameObject m_PromptMessageGO;
        [SerializeField] private TextMeshProUGUI m_PromptMessageText;

        [Header("Progress Bar")]
        [SerializeField] private GameObject m_ProgressBarGO;
        [SerializeField] private Image m_ProgressBarImage;
        #endregion
        #region Unity Method
        void Start()
        {
            Cursor.lockState=CursorLockMode.Locked;
            Cursor.visible=true;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// It shows the interaction text on the UI.
        /// </summary>

        public void SetPromptText(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                m_PromptMessageGO.SetActive(false);
            }
            else
            {
                if (!m_PromptMessageGO.activeSelf)
                {
                    m_PromptMessageGO.SetActive(true);
                }
                m_PromptMessageText.text = $"[F] {message}";
            }
        }
        /// <summary>
        /// to remove unnecessary ui after leaving the interacted object
        /// </summary>
        public void HidePrompt()
        {
            if (m_PromptMessageGO.activeSelf)
            {
                m_PromptMessageGO.SetActive(false);
            }

        }
        /// <summary>
        /// Show progress in ui for holding interact 
        /// </summary>
        public void UpdateProgressBar(float fillAmount)
        {
            if (!m_ProgressBarGO.activeSelf)
            {
                m_ProgressBarGO.SetActive(true);
            }

            m_ProgressBarImage.fillAmount = fillAmount;
        }

        public void HideProgressBar()
        {
            if (m_ProgressBarGO.activeSelf)
            {
                m_ProgressBarGO.SetActive(false);
            }

        }
        #endregion
    }

}
