using System.Collections;
using UnityEngine;

namespace Tools
{
    /// <summary>
    /// Class which holds useful coroutines.
    /// </summary>
    public static class Coroutines
    {
        /// <summary>
        /// Coroutine that changes a transform's local scale to a target scale in the given time.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="targetScale"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static IEnumerator LerpLocalScaleTo(this Transform transform, Vector3 targetScale, float time)
        {
            if (!transform) throw new System.Exception("Transform is null!");
            
            float elapsedTime = 0;
            Vector3 startingScale = transform.localScale;
            while (elapsedTime < time)
            {
                transform.localScale = Vector3.Lerp(startingScale, targetScale, elapsedTime / time);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.localScale = targetScale;
        }

        /// <summary>
        /// Coroutine that changes a transform's local scale in a way to make it look like it's shaking.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="startingScale"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static IEnumerator ShakeFor(this Transform transform, Vector3 startingScale, float duration)
        {
            if (!transform) throw new System.Exception("Transform is null!");
            
            float elapsedTime = 0;
            while (elapsedTime < duration)
            {
                transform.localScale = startingScale + Random.insideUnitSphere * 0.1f;
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.localScale = startingScale;
        }
    }
}