namespace Interfaces
{
    /// <summary>
    /// Interface for behaviours that multiply the points earned by matching Tiles.
    /// See <see cref="Managers.ScoreManager"/> for more information (as it will be probably used there.)
    /// </summary>
    public interface ITileMatcherMultiplier
    {
        /// <summary>
        /// All the multiplier receives the variable to be changed.
        /// </summary>
        /// <param name="score"></param>
        void ChangeScore(ref int score);
    }
}