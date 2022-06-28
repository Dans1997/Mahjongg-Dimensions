using System;

namespace UI.Buttons
{
    /// <summary>
    /// Class responsible for notifying when a "go to main menu button" is pressed.
    /// </summary>
    public class GoToMainMenuButton : UIButton
    {
        /// <summary>
        /// Fired when the start button is pressed.
        /// </summary>
        public static event Action OnGoToMainMenuPressed;
        
        /// <summary>
        /// Fire event so that the game can start.
        /// </summary>
        protected override void ProcessClick() => OnGoToMainMenuPressed?.Invoke();
    }
}