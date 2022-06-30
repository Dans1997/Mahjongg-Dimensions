using System;
using System.Diagnostics.CodeAnalysis;
using ScriptableObjects;
using Tools;
using UI.Buttons;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Class responsible for sound effects in the game.
    /// </summary>
    public class SoundEffectManager : MonoBehaviour
    {
        /// <summary>
        /// Fired every time a sound effect needs to be played.
        /// </summary>
        public static Action<SoundEffect> OnPlaySoundEffect { get; private set; }

        /// <summary>
        /// All sound effects are 2D for now, just a one shot audio source will suffice.
        /// </summary>
        AudioSource oneShotAudioSource;
        
        /// <summary>
        /// Are sound effects muted?
        /// </summary>
        bool isMuted;
        
        // Awake is called when the script instance is being loaded
        void Awake()
        {
            oneShotAudioSource = CreateAudioSource();
            OnPlaySoundEffect += PlaySound;
        }

        // Start is called before the first frame update
        void Start() => SoundEffectToggleButton.OnSoundEffectToggle += ToggleSoundTrack;
        
        // OnDestroy is called when the script is destroyed
        void OnDestroy()
        {
            SoundEffectToggleButton.OnSoundEffectToggle -= ToggleSoundTrack;
            OnPlaySoundEffect -= PlaySound;
        }

        /// <summary>
        /// Callback for the sound effect toggle button.
        /// Will flip the value of <see cref="isMuted"/>.
        /// </summary>
        void ToggleSoundTrack() => isMuted ^= true;

        /// <summary>
        /// Creates an audio source and returns its reference.
        /// </summary>
        /// <returns></returns>
        [return: NotNull]
        AudioSource CreateAudioSource()
        {
            return gameObject.AddComponent<AudioSource>() ?? throw new Exception("Audio source creation failed!");
        }

        /// <summary>
        /// Plays the given sound effect.
        /// </summary>
        /// <param name="soundEffect"></param>
        void PlaySound(SoundEffect soundEffect)
        {
            if (!oneShotAudioSource) return;
            if (isMuted) return;
            if (soundEffect == null) return;
            
            oneShotAudioSource.volume = soundEffect.Volume;
            oneShotAudioSource.pitch = soundEffect.Pitch;
            oneShotAudioSource.PlayOneShot(soundEffect.AudioClip);
        }
    }

    /// <summary>
    /// Extension methods related to <see cref="SoundEffectManager"/>.
    /// </summary>
    public static class SoundEffectManagerExtensions
    {
        /// <summary>
        /// Play a random sound from a list of sound effects.
        /// </summary>
        /// <param name="soundEffects"></param>
        public static void PlayRandomSound(this SoundEffect[] soundEffects)
        {
            if (!soundEffects.HasElements()) return;
            SoundEffectManager.OnPlaySoundEffect?.Invoke(soundEffects!.RandomElement());
        }
    }
}