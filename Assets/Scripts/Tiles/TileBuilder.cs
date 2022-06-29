using System;
using Interfaces;
using Managers;
using UnityEngine;

namespace Tiles
{
    /// <summary>
    /// Class which represents a tile builder, like <see cref="Cubes.CubeTowerBuilder"/>.
    /// Created to be able to make different types of game boards in the future.
    /// </summary>
    public abstract class TileBuilder : MonoBehaviour, IBoardBuilder
    {
        /// <summary>
        /// Fired when the board is built.
        /// </summary>
        public static Action OnAllTilesBuilt { get; set; }
        
        /// <summary>
        /// Fired when all tiles built by this builder are matched by tile matchers, like <see cref="Cubes.CubeMatcher"/>.
        /// This is static based on the assumption that only one tile builder will be used at a time.
        /// </summary>
        public static Action OnAllTilesMatched { get; set; }
        
        // Start is called before the first frame update
        void Start() => GameStartManager.OnGameStarted += HandleGameStarted;
        
        // OnDestroy is called when the script is being destroyed
        void OnDestroy() => GameStartManager.OnGameStarted -= HandleGameStarted;
        
        /// <summary>
        /// Callback for when the game starts.
        /// </summary>
        void HandleGameStarted() => BuildGameBoard();
        
        /// <summary>
        /// Builds the game board.
        /// </summary>
        public abstract void BuildGameBoard();
    }
}