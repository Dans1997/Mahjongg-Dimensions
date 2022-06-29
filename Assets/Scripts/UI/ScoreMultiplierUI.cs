using MatcherMultipliers;
using UI.ManagerDependant;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Class responsible for showing the multiplier value on the screen.
    /// </summary>
    public class ScoreMultiplierUI : ManagerDependantUI
    {
        [SerializeField] MatcherMultiplier multiplier;
        
        /// <summary>
        /// Sub to the score manager's score changed event.
        /// </summary>
        protected override void SubToManager()
        {
            if (multiplier == null) return;
            multiplier.OnMultiplierChanged += OnMultiplierChanged;
        }

        /// <summary>
        /// Unsub from the score manager's score changed event.
        /// </summary>
        protected override void UnsubFromManager()
        {
            if (multiplier == null) return;
            multiplier.OnMultiplierChanged -= OnMultiplierChanged;
        }

        /// <summary>
        /// Callback for when the multiplier's value changes.
        /// </summary>
        /// <param name="currentMultiplier"></param>
        void OnMultiplierChanged(int currentMultiplier)
        {
            TextReference!.text = $"x{currentMultiplier}";
        }

        /// <summary>
        /// Callback for when the game ends.
        /// </summary>
        /// <param name="endMessage"></param>
        protected override void OnGameOver(string endMessage)
        {
            base.OnGameOver(endMessage);
            TextReference!.text = "";
        }
    }
}