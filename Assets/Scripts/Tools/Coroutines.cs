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
    }
}