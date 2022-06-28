using UI.Buttons;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Class responsible for dealing with the main menu.
    /// </summary>
    public class PauseUI : AwaitableUI
    {
        // Start is called before the first frame update
        void Start() => GoToMainMenuButton.OnGoToMainMenuPressed += OnGoToMainMenuButtonPressed;
        
        // OnDestroy is called when the script instance is being destroyed.
        void OnDestroy() => GoToMainMenuButton.OnGoToMainMenuPressed -= OnGoToMainMenuButtonPressed;

        /// <summary>
        /// Called whenever a <see cref="GoToMainMenuButton"/> is pressed.
        /// This is needed in order to unpause the game when the main menu is closed.
        /// See <see cref="AwaitableUI"/> for more information.
        /// </summary>
        void OnGoToMainMenuButtonPressed()
        {
            if (!TryGetComponent(out Canvas canvas)) return;
            canvas!.enabled = false;
        }
    }
}