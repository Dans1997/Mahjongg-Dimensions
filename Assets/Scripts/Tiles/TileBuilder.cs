using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Cubes;
using Interfaces;
using Managers;
using UnityEngine;

namespace Tiles
{
    /// <summary>
    /// Class which represents a tile builder, like <see cref="CubeBoardBuilder"/>.
    /// Created to be able to make different types of game boards in the future.
    /// </summary>
    public abstract class TileBuilder : MonoBehaviour, IBoardBuilder
    {
        /// <summary>
        /// Fired when the board is built.
        /// </summary>
        public static event Action OnAllTilesBuilt;

        /// <summary>
        /// Fired when all tiles built by this builder are matched by tile matchers, like <see cref="ClickTileMatcher"/>.
        /// This is static based on the assumption that only one tile builder will be used at a time.
        /// </summary>
        public static event Action OnAllTilesMatched;
        
        /// <summary>
        /// Collection of tiles after they are built.
        /// </summary>
        public static Dictionary<Vector3, Tile> BuiltTiles { get; protected set; }

        // Start is called before the first frame update
        void Start()
        {
            GameStartManager.OnGameStarted += HandleGameStarted;
            TileMatcher.OnMatch += HandleMatch;
        }

        // OnDestroy is called when the script is being destroyed
        void OnDestroy()
        {
            GameStartManager.OnGameStarted -= HandleGameStarted;
            TileMatcher.OnMatch -= HandleMatch;
        }
        
        /// <summary>
        /// Callback for when the game starts.
        /// </summary>
        void HandleGameStarted() => BuildGameBoard();
        
        /// <summary>
        /// Builds the game board.
        /// </summary>
        public abstract void BuildGameBoard();
        
        /// <summary>
        /// Called when this builder finishes building the game board.
        /// </summary>
        protected static void InvokeOnAllTilesBuilt() => OnAllTilesBuilt?.Invoke();

        /// <summary>
        /// Callback for when a tile is matched.
        /// </summary>
        static void HandleMatch([NotNull] Stack<Tile> matchedTiles)
        {
            if (matchedTiles == null) throw new ArgumentNullException(nameof(matchedTiles));
            if (BuiltTiles == null) throw new InvalidOperationException("BuiltTiles is null.");
            foreach (Tile tile in matchedTiles)
            {
                if (!tile) throw new InvalidOperationException("Tile is null.");
                if (!BuiltTiles.ContainsKey(tile.InitialPosition)) throw new InvalidOperationException("BuiltTiles does not contain the tile.");
                BuiltTiles.Remove(tile.InitialPosition);
            }
            
            if (BuiltTiles.Count == 0) OnAllTilesMatched?.Invoke();
        }
    }
}