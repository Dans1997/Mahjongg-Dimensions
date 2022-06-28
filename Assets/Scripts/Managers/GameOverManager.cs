using System;
using Tiles;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Class responsible for ending the game.
    /// </summary>
    public class GameOverManager : MonoBehaviour
    {
        /// <summary>
        /// Called when game ends.
        /// Comes with a end game message (for now displayed in the game over UI.)
        /// </summary>
        public static Action<string> OnGameOver { get; set; }
        
        // Start is called before the first frame update
        void Start()
        {
            TileBuilder.OnAllTilesMatched += OnAllTilesMatched;
            TimerManager.OnTimeOut += OnTimeOut;
        }

        // OnDestroy is called when the script is destroyed
        void OnDestroy()
        {
            TileBuilder.OnAllTilesMatched -= OnAllTilesMatched;
            TimerManager.OnTimeOut -= OnTimeOut;
        }
        
        /// <summary>
        /// Callback for when all tiles from the tile builder are matched.
        /// </summary>
        static void OnAllTilesMatched() => EndGame("You won!");

        /// <summary>
        /// Callback for when the timer runs out.
        /// </summary>
        static void OnTimeOut() => EndGame("Time's up!");

        /// <summary>
        /// Wrapper method to end the game.
        /// </summary>
        /// <param name="endMessage"></param>
        static void EndGame(string endMessage)
        {
            OnGameOver?.Invoke(endMessage);
            OnGameOver = null;
        }
    }
}