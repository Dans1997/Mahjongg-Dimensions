using Managers;
using Managers.HighScoreManager;
using TMPro;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Class which implements the game over screen.
    /// For now, used by <see cref="Managers.PauseManager"/> when the game ends.
    /// </summary>
    public class GameOverUI : AwaitableUI
    {
        [Header("Other References")]
        [SerializeField] TMP_Text scoreText;
        [SerializeField] TMP_Text highScoreText;
        
        // Start is called before the first frame update
        void Start()
        {
            if (scoreText != null) scoreText.text = $"Score: \n{ScoreManager.CurrentScore}";
            ShowHighScore();
        }

        /// <summary>
        /// Sets a high score if it was saved before. Otherwise, it sets the high score to the current score.
        /// </summary>
        void ShowHighScore()
        {
            int highScore = ScoreManager.CurrentScore;
            int aux = HighScoreManager.CurrentHighScore;
            if (aux > 0) highScore = aux;
            if (highScoreText != null) highScoreText.text = $"High Score: \n{highScore}";
        }
    }
}