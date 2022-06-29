using Interfaces;
using UnityEngine;

namespace MatcherMultipliers
{
    /// <summary>
    /// Class which represents a score multiplier.
    /// </summary>
    public abstract class MatcherMultiplier : MonoBehaviour, ITileMatcherMultiplier
    {
        [SerializeField] [Range(1, 999)] protected int minimumMultiplier = 1;
        [SerializeField] [Range(1, 999)] protected int maximumMultiplier = 5;
        
        /// <summary>
        /// Current score multiplier.
        /// </summary>
        protected int CurrentMultiplier { get; private set; }

        /// <summary>
        /// Fired whenever the value used to multiply the points changes.
        /// </summary>
        public event System.Action<int> OnMultiplierChanged;
        
        /// <summary>
        /// Will change the value used to multiply the points.
        /// </summary>
        /// <param name="score"></param>
        public abstract void ChangeScore(ref int score);
        
        /// <summary>
        /// Setter for the current multiplier.
        /// </summary>
        /// <param name="multiplier"></param>
        protected void SetMultiplier(int multiplier)
        {
            CurrentMultiplier = multiplier;
            OnMultiplierChanged?.Invoke(multiplier);
        }

        /// <summary>
        /// Returns the value of the current multiplier back to original value.
        /// </summary>
        protected void ResetMultiplier() => SetMultiplier(minimumMultiplier);
    }
}