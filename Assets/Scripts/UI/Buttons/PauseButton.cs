using System;

namespace UI.Buttons
{
    /// <summary>
    /// Class which implements the behavior of the pause button.
    /// </summary>
    public class PauseButton : UIButton
    {
        /// <summary>
        /// Fired when the start button is pressed.
        /// </summary>
        public static event Action OnPauseButtonPressed;

        /// <summary>
        /// Fire event so that the game can start.
        /// </summary>
        protected override void ProcessClick() => OnPauseButtonPressed?.Invoke();
    }
}