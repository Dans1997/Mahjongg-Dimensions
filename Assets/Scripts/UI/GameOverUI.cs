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
            // TODO: scoreText.text = $"Score: \n{ScoreManager.CurrentScore}";
            // TODO: highScoreText.text = $"High Score: \n{ScoreManager.HighScore}";
        }
    }
}