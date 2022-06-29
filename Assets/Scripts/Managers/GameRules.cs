using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Class which stores the information about a game.
    /// Can be later extended to support multiple game modes.
    /// </summary>
    public readonly struct GameRules
    {
        /// <summary>
        /// The number of same-type tiles that must be clicked in order to form a match.
        /// </summary>
        public int NumberOfTilesToMatch { get; }
        
        /// <summary>
        /// Dimensions of the game board.
        /// </summary>
        public Vector3 GameBoardDimensions { get; }
        
        /// <summary>
        /// How many points are earned for each match.
        /// </summary>
        public int BasePointsForEachMatch { get; }
        
        /// <summary>
        /// The number of same-type tiles that exist in the game board at a time.
        /// </summary>
        public int NumberOfPossibleTileTypes { get; }
        
        /// <summary>
        /// Time limit for a round of the game.
        /// </summary>
        public int TimeLimitInSeconds { get; }

        /// <summary>
        /// Default constructor for the game rules.
        /// </summary>
        /// <param name="numberOfTilesToMatch"></param>
        /// <param name="gameBoardDimensions"></param>
        /// <param name="basePointsForEachMatch"></param>
        /// <param name="numberOfPossibleTileTypes"></param>
        /// <param name="timeLimitInSeconds"></param>
        public GameRules(int numberOfTilesToMatch, Vector3 gameBoardDimensions, int basePointsForEachMatch, 
            int numberOfPossibleTileTypes, int timeLimitInSeconds)
        {
            NumberOfTilesToMatch = numberOfTilesToMatch;
            GameBoardDimensions = gameBoardDimensions;
            BasePointsForEachMatch = basePointsForEachMatch;
            NumberOfPossibleTileTypes = numberOfPossibleTileTypes;
            TimeLimitInSeconds = timeLimitInSeconds;
        }

        /// <summary>
        /// According to the rules, is the given collection of tiles full?
        /// </summary>
        /// <param name="collectionSize"></param>
        /// <returns></returns>
        public bool IsCollectionFull(int collectionSize) => collectionSize == NumberOfTilesToMatch;
    }
}