using UnityEngine;
namespace GameProject.Runtime.Core
{
    /// <summary>
    /// The interface that all interactable objects (Door, Chest, Key) must implement.
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        /// Triggered when the player presses the interaction key.
        /// </summary>
        void Interact();

        /// <summary>
        /// Returns the interaction text to be displayed on the UI (Ex: "Open Door").
        /// </summary>
        string GetInteractionPrompt();
    }
}
