namespace UI.Buttons
{
    /// <summary>
    /// Class responsible for notifying when any alive "play again" is pressed.
    /// Most likely used in the <see cref="GameOverUI"/>.
    /// </summary>
    public class PlayAgainButton : UIButton
    {
        /// <summary>
        /// Fired when this button is pressed.
        /// </summary>
        public static event System.Action OnPlayAgainPressed;
        
        /// <summary>
        /// Fire event so that the game can start.
        /// </summary>
        protected override void ProcessClick() => OnPlayAgainPressed?.Invoke();
    }
}