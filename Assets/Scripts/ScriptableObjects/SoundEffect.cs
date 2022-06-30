using UnityEngine;

namespace ScriptableObjects
{
    /// <summary>
    /// Scriptable object which holds the data for a sound effect to be played.
    /// </summary>
    [CreateAssetMenu(fileName = "New Sound Effect", menuName = "Sound Effect", order = 0)]
    public class SoundEffect : ScriptableObject
    {
        [field: SerializeField] public AudioClip AudioClip { get; private set; } = null;
        [field: SerializeField] public float Volume { get; private set; } = 1f;
        [field: SerializeField] public float Pitch { get; private set; } = 1f;
    }
}