using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    /// <summary>
    /// A class which stores and manages the game's state.
    /// Important: should have only one per scene.
    /// </summary>
    public class GameStateManager : MonoBehaviour
    {
        [Tooltip("The game state to be set when start is called.")]
        [FormerlySerializedAs("gameStateOnStart")]
        [SerializeField] GameState gameStateOnAwake = GameState.MainMenu;
        
        /// <summary>
        /// Enum representing game state.
        /// </summary>
        public enum GameState { MainMenu, Loading, Game, GameOver }

        /// <summary>
        /// The current state of the game.
        /// </summary>
        public static GameState CurrentGameState { get; private set; } = GameState.MainMenu;
        
        // Awake is called before Start
        void Awake()
        {
            if (FindObjectsOfType<GameStateManager>()?.Length > 1)
            {
                throw new Exception("Found more than one GameStateManager in scene.");
            }
            SetGameState(gameStateOnAwake);
        }

        // OnApplicationQuit is called when the application is about to quit
        void OnApplicationQuit() => SetGameState(GameState.GameOver);

        // OnDestroy is called when the script is destroyed
        void OnDestroy() => SetGameState(GameState.Loading);

        /// <summary>
        /// Sets a new current game state.
        /// </summary>
        /// <param name="gameState"></param>
        static void SetGameState(GameState gameState) => CurrentGameState = gameState;
    }
}