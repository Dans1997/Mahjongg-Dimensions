namespace Interfaces
{
    /// <summary>
    /// Interface for behaviours that save/load high scores.
    /// </summary>
    public interface IHighScoreHandler
    {
        int GetHighScore();
        void SetHighScore(int score);
    }
}