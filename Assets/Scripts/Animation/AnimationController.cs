using System.Collections;
using UnityEngine;

namespace Animations
{
    /// <summary>
    /// General wrapper for animator to avoid code duplication.
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class AnimationController : MonoBehaviour
    {
        // Cached Components
        Animator animator = null;
    
        // Start is called before the first frame update
        void Start() 
        {
            animator = GetComponent<Animator>();
            animator.StartPlayback();
            animator.speed = 1f;
        }
    
        // Public Calls
        public float GetCurrentAnimationLength() => animator.GetCurrentAnimatorStateInfo(0).length;
        public void SetFloat(int parameterHash, float value) => animator.SetFloat(parameterHash, value);
        public void SetTrigger(int parameterHash) => animator.SetTrigger(parameterHash);
        public void PlayAnimation(int animationHash, bool playBackwards = false)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).shortNameHash != animationHash) animator.Play(animationHash, 0);
            animator.StartPlayback();
            animator.speed = playBackwards ? -1f : 1f;
        }
    }
    
    /// <summary>
    /// Implements animation controller extensions.
    /// </summary>
    public static class AnimationControllerExtensions
    {
        /// <summary>
        /// Plays the given animation until the end.
        /// </summary>
        /// <param name="animator"></param>
        /// <param name="animationHash"></param>
        /// <param name="playBackwards"></param>
        /// <returns></returns>
        public static IEnumerator PlayAnimationUntilTheEnd(this AnimationController animator, int animationHash, bool playBackwards = false)
        {
            animator.PlayAnimation(animationHash, playBackwards);
            yield return null; yield return new WaitForSeconds(animator.GetCurrentAnimationLength());
        }
    }
}