using System;

namespace UI.Buttons
{
    /// <summary>
    /// Class responsible for notifying the when the start button is pressed.
    /// </summary>
    public class StartGameButton : UIButton
    {
        /// <summary>
        /// Fired when the start button is pressed.
        /// </summary>
        public static Action OnStartGameButtonPressed { get; set; }
        
        /// <summary>
        /// Fire event so that the game can start.
        /// </summary>
        protected override void ProcessClick()
        {
            OnStartGameButtonPressed?.Invoke();
        }
    }
}