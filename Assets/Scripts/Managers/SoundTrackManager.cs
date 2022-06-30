using System;
using Tools;
using UI.Buttons;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Class responsible for managing the game's soundtrack.
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class SoundTrackManager : MonoBehaviour
    {
        /// <summary>
        /// The audio source component.
        /// </summary>
        AudioSource audioSource;

        /// <summary>
        /// The audio clip to play.
        /// </summary>
        [SerializeField] AudioClip[] audioClips;
        
        // Awake is called when the script instance is being loaded
        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            if (!audioClips.HasElements()) throw new Exception("SoundTrackManager: Audio clip not set.");
            audioSource!.clip = audioClips.RandomElement();
            audioSource.loop = true;
            audioSource.Play();
        }

        // Start is called before the first frame update
        void Start() => SoundTrackToggleButton.OnSoundTrackToggle += ToggleSoundTrack;
        
        // OnDestroy is called when the script instance is being destroyed
        void OnDestroy() => SoundTrackToggleButton.OnSoundTrackToggle -= ToggleSoundTrack;

        /// <summary>
        /// Callback for the sound track toggle button.
        /// Will toggle the sound track on and off.
        /// </summary>
        void ToggleSoundTrack() => audioSource!.mute ^= true;
    }
}