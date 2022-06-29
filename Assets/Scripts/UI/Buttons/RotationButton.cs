namespace UI.Buttons
{
    /// <summary>
    /// Class responsible for notifying the UI manager that the rotation button has been pressed.
    /// See <see cref="Managers.TileRotationManager"/> for more information.
    /// </summary>
    public class RotationButton : UIButton
    {
        /// <summary>
        /// Fired when the button is pressed.
        /// </summary>
        public event System.Action OnRotationButtonClicked;
        
        /// <summary>
        /// Invokes the button press event.
        /// </summary>
        protected override void ProcessClick() => OnRotationButtonClicked?.Invoke();
    }
}
