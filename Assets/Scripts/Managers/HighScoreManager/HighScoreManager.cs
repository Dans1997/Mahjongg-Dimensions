using Interfaces;
using UnityEngine;

namespace Managers.HighScoreManager
{
    /// <summary>
    /// Class which represents a high score manager.
    /// </summary>
    [RequireComponent(typeof(IHighScoreHandler))]
    public class HighScoreManager : MonoBehaviour
    {
        /// <summary>
        /// Current user high score.
        /// </summary>
        public static int CurrentHighScore { get; private set; }
        
        // Awake is called when the script instance is being loaded
        void Awake() => CurrentHighScore = GetComponent<IHighScoreHandler>()?.GetHighScore() ?? 0;

        // OnDestroy is called when the script is destroyed
        void OnDestroy() => GetComponent<IHighScoreHandler>()?.SetHighScore(ScoreManager.CurrentScore);
    }
}