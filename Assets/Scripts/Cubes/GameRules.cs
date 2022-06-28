using UnityEngine;

namespace Cubes
{
    /// <summary>
    /// Class which stores the information about a game.
    /// Can be later extended to support multiple game modes.
    /// </summary>
    public readonly struct GameRules
    {
        /// <summary>
        /// The number of same-type cubes that must be clicked in order to form a match.
        /// </summary>
        public int NumberOfCubesToMatch { get; }
        
        /// <summary>
        /// Dimensions of the game board.
        /// </summary>
        public Vector3 CubeGridDimensions { get; }
        
        /// <summary>
        /// How many points are earned for each match.
        /// </summary>
        public int BasePointsForEachMatch { get; }
        
        /// <summary>
        /// The number of same-type cubes that exist in the game board at a time.
        /// </summary>
        public int NumberOfPossibleTileTypes { get; }
        
        /// <summary>
        /// Time limit for a round of the game.
        /// </summary>
        public int TimeLimitInSeconds { get; }

        /// <summary>
        /// Default constructor for the game rules.
        /// </summary>
        /// <param name="numberOfCubesToMatch"></param>
        /// <param name="cubeGridDimensions"></param>
        /// <param name="basePointsForEachMatch"></param>
        /// <param name="numberOfPossibleTileTypes"></param>
        /// <param name="timeLimitInSeconds"></param>
        public GameRules(int numberOfCubesToMatch, Vector3 cubeGridDimensions, int basePointsForEachMatch, 
            int numberOfPossibleTileTypes, int timeLimitInSeconds)
        {
            NumberOfCubesToMatch = numberOfCubesToMatch;
            CubeGridDimensions = cubeGridDimensions;
            BasePointsForEachMatch = basePointsForEachMatch;
            NumberOfPossibleTileTypes = numberOfPossibleTileTypes;
            TimeLimitInSeconds = timeLimitInSeconds;
        }

        /// <summary>
        /// According to the rules, is the given collection of cubes full?
        /// </summary>
        /// <param name="collectionSize"></param>
        /// <returns></returns>
        public bool IsCollectionFull(int collectionSize) => collectionSize == NumberOfCubesToMatch;

        /// <summary>
        /// Validates two cubes to see if they match.
        /// </summary>
        /// <param name="clickedCube"></param>
        /// <param name="peekedCube"></param>
        /// <returns>Whether or not the cubes are a match.</returns>
        public static bool DoCubesMatch(Cube clickedCube, Cube peekedCube)
        {
            if (!clickedCube) throw new System.Exception("Clicked cube is null.");
            if (!peekedCube) return true;
            if (peekedCube == clickedCube) return false;
            return clickedCube.CubeType == peekedCube.CubeType;
        }
    }
}