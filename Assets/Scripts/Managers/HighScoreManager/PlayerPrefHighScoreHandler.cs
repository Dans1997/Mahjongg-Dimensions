using Interfaces;
using UnityEngine;

namespace Managers.HighScoreManager
{
    /// <summary>
    /// Class responsible for saving/loading high score using PlayerPrefs.
    /// </summary>
    public class PlayerPrefHighScoreHandler : MonoBehaviour, IHighScoreHandler
    {
        /// <summary>
        /// PlayerPrefs key for the high score.
        /// </summary>
        const string HighScoreKey = "HighScore";
        
        /// <summary>
        /// Returns the current high score from PlayerPrefs.
        /// </summary>
        /// <returns></returns>
        public int GetHighScore() => PlayerPrefs.GetInt(HighScoreKey, 0);

        /// <summary>
        /// Sets a new high score if the current score is higher than the current high score.
        /// </summary>
        /// <param name="score"></param>
        public void SetHighScore(int score)
        {
            if (GetHighScore() >= score) return;
            PlayerPrefs.SetInt(HighScoreKey, score);
        }
    }
}