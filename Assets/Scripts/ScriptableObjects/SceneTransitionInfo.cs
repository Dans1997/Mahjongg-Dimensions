using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    /// <summary>
    /// /// Unique ID for each scene transition.
    /// </summary>
    public enum TransitionType { BlackFade }
    
    /// <summary>
    /// Transition for scene loading.
    /// </summary>
    [CreateAssetMenu]
    public class SceneTransitionInfo : ScriptableObject
    {
        [field: FormerlySerializedAs("transitionType")] 
        [field: SerializeField] public TransitionType TransitionType { get; private set; } = TransitionType.BlackFade;
        
        [field: FormerlySerializedAs("transitionPartOne")] 
        [field: SerializeField] public AnimationClip PartOne { get; private set; } = null;
        
        [field: FormerlySerializedAs("transitionPartTwo")] 
        [field: SerializeField] public AnimationClip PartTwo { get; private set; } = null;
    }
}
