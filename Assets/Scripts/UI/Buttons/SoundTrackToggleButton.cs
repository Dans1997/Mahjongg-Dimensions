using System;

namespace UI.Buttons
{
    /// <summary>
    /// Class responsible for notifying the user of a button which turns on and off the soundtrack.
    /// </summary>
    public class SoundTrackToggleButton : UIButton
    {
        /// <summary>
        /// Fires when the button is clicked.
        /// </summary>
        public static event Action OnSoundTrackToggle;
        
        /// <summary>
        /// In this case, only fires the event <see cref="OnSoundTrackToggle"/>.
        /// </summary>
        protected override void ProcessClick() => OnSoundTrackToggle?.Invoke();
    }
}