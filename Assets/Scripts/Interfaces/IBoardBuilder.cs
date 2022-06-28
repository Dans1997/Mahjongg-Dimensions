namespace Interfaces
{
    /// <summary>
    /// Interface for game board builder.
    /// Created because different game board builders have different ways of building the game board.
    /// </summary>
    public interface IBoardBuilder
    {
        /// <summary>
        /// Builds the game board.
        /// </summary>
        public void BuildGameBoard();
    }
}