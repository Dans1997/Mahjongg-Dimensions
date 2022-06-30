namespace UI.Buttons
{
    /// <summary>
    /// Class responsible for notifying that the sound effect toggle button was clicked.
    /// </summary>
    public class SoundEffectToggleButton : UIButton
    {
        /// <summary>
        /// Fired whenever this button is clicked.
        /// </summary>
        public static event System.Action OnSoundEffectToggle;
        
        /// <summary>
        /// In this case, simply fire the <see cref="OnSoundEffectToggle"/> event.
        /// </summary>
        protected override void ProcessClick() => OnSoundEffectToggle?.Invoke();
    }
}