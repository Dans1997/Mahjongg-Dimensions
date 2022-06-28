using System.Globalization;
using Managers;

namespace UI.ManagerDependant
{
    /// <summary>
    /// Class responsible for displaying the current score of the game.
    /// </summary>
    public class ScoreUI : ManagerDependantUI
    {
        /// <summary>
        /// Sub to the score manager's score changed event.
        /// </summary>
        protected override void SubToManager() => ScoreManager.OnScoreChanged += OnScoreChanged;

        /// <summary>
        /// Unsub from the score manager's score changed event.
        /// </summary>
        protected override void UnsubFromManager() => ScoreManager.OnScoreChanged -= OnScoreChanged;

        /// <summary>
        /// Callback for when the timer changes its value.
        /// </summary>
        /// <param name="currentScore"></param>
        void OnScoreChanged(int currentScore)
        {
            TextReference!.text = currentScore.ToString("00000", CultureInfo.InvariantCulture);
        }
    }
}