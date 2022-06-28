using Cubes;
using ScriptableObjects;
using UI.Buttons;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Class responsible for managing game state.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// Reference to the current game rules.
        /// Note: these default values are taken from the assignment document.
        /// </summary>
        public static GameRules GameRules = new (numberOfCubesToMatch: 2, cubeGridDimensions: new Vector3(4,4,4), 
            basePointsForEachMatch: 100, numberOfPossibleTileTypes: 6, 
#if UNITY_EDITOR
            timeLimitInSeconds: 30);
#else
            timeLimitInSeconds: 5 * 60);
#endif

        /// <summary>
        /// For now (at least), the game manager is responsible for loading scenes.
        /// </summary>
        void Start()
        {
            StartGameButton.OnStartGamePressed += OnStartGamePressed;
            GoToMainMenuButton.OnGoToMainMenuPressed += OnGoToMainMenuButtonPressed;
            PlayAgainButton.OnPlayAgainPressed += OnPlayAgainButtonPressed;
        }

        void OnDestroy()
        {
            StartGameButton.OnStartGamePressed -= OnStartGamePressed;
            GoToMainMenuButton.OnGoToMainMenuPressed -= OnGoToMainMenuButtonPressed;
            PlayAgainButton.OnPlayAgainPressed -= OnPlayAgainButtonPressed;
        }

        /// <summary>
        /// Callback for when the start game button is pressed.
        /// </summary>
        static void OnStartGamePressed() => LoadScene(SceneLoader.MainGameSceneName);

        /// <summary>
        /// Callback for when a go to main menu button is pressed.
        /// </summary>
        static void OnGoToMainMenuButtonPressed() => LoadScene(SceneLoader.MainMenuSceneName);
        
        /// <summary>
        /// Callback for when the play again button is pressed.
        /// </summary>
        static void OnPlayAgainButtonPressed() => LoadScene(SceneLoader.MainGameSceneName);

        /// <summary>
        /// Tells the scene loader to load the given scene name.
        /// </summary>
        /// <param name="sceneName"></param>
        static void LoadScene(string sceneName) => SceneLoader.LoadSceneAction?.Invoke(sceneName, TransitionType.BlackFade);
    }
}
