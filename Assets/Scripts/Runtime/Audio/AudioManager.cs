using System.Diagnostics;
using UnityEngine;
namespace GameProject.Runtime.Audio
{
    /// <summary>
    /// sound management system use to play SFX
    /// using singelton
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        #region Singleton
        public static AudioManager Instance { get; private set; }
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

        #region Fields
        [Header("Source")]
        [SerializeField] private AudioSource m_SFXSource;
        #endregion

        #region Public Methods
        public void PlaySFX(AudioClip audio, float volume = 1f)
        {
            if (audio == null)
            {
                return;
            }
            m_SFXSource.PlayOneShot(audio, volume);
        }
        #endregion
    }

}
