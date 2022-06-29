using System.Collections;
using UnityEngine;

namespace MatcherMultipliers
{
    /// <summary>
    /// Increases the multiplier cumulatively (from 2x to 3x, 4x, and so on)
    /// every time the player takes less than X seconds from the last tile match to match a new set of tiles.
    /// </summary>
    public class TimeWindowMatcher : MatcherMultiplier
    {
        [SerializeField] float timeWindow = 3f;

        // Cached Components
        Coroutine resetMultiplierCoroutine;
        float lastMatchTime;

        // Start is called before the first frame update
        void Start() => ResetMultiplier();

        /// <summary>
        /// Multiplies the score received by the current state of this class.
        /// </summary>
        /// <param name="score"></param>
        public override void ChangeScore(ref int score)
        {
            ProcessMatch();
            score *= CurrentMultiplier;
        }
        
        /// <summary>
        /// This can be called on the change score call because every score change happens RIGHT AFTER a match.
        /// </summary>
        void ProcessMatch()
        {
            float now = Time.time;

            // If the time since the last match is less than 3 seconds, increase the multiplier
            if (now - lastMatchTime < timeWindow)
            {
                SetMultiplier(Mathf.Clamp(CurrentMultiplier + 1, minimumMultiplier, maximumMultiplier));
                if (resetMultiplierCoroutine != null) StopCoroutine(resetMultiplierCoroutine);
                resetMultiplierCoroutine = StartCoroutine(ResetMultiplierCoroutine());
            }
            else
            {
                ResetMultiplier();
            }
            
            lastMatchTime = now;
        }
        
        /// <summary>
        /// Coroutine that resets the multiplier to its original value after a certain amount of time.
        /// </summary>
        /// <returns></returns>
        IEnumerator ResetMultiplierCoroutine()
        {
            yield return new WaitForSeconds(timeWindow);
            ResetMultiplier();
        }
    }
}