using Managers;
using ScriptableObjects;
using Tools;
using UnityEngine;

namespace Sounds
{
    /// <summary>
    /// Class responsible for playing a sound on Start();
    /// </summary>
    public class PlaySoundOnStart : MonoBehaviour
    {
        [SerializeField] SoundEffect[] soundEffects;
        [SerializeField] bool playAllSounds;
        [SerializeField] bool destroyOnFinish = true;
        
        // Start is called before the first frame update
        void Start()
        {
            if (playAllSounds && soundEffects.HasElements())
            {
                foreach (SoundEffect soundEffect in soundEffects)
                {
                    SoundEffectManager.OnPlaySoundEffect?.Invoke(soundEffect);
                }

                return;
            }

            soundEffects.PlayRandomSound();
            if (destroyOnFinish) Destroy(this, 0.5f);
        }
    }
}