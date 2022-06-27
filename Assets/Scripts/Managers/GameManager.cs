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
        public static GameRules GameRules = new (2, new Vector3(4,4,4), 100, 6);

        /// <summary>
        /// For now (at least), the game manager is responsible for loading scenes.
        /// </summary>
        void Start()
        {
            StartGameButton.OnStartGameButtonPressed += OnStartGameButtonPressed;
            GoToMainMenuButton.OnGoToMainMenuButtonPressed += OnGoToMainMenuButtonPressed;
        }

        void OnDestroy()
        {
            StartGameButton.OnStartGameButtonPressed -= OnStartGameButtonPressed;
            GoToMainMenuButton.OnGoToMainMenuButtonPressed -= OnGoToMainMenuButtonPressed;
        }

        /// <summary>
        /// Called when the start game button is pressed.
        /// </summary>
        static void OnStartGameButtonPressed() => LoadScene(SceneLoader.MainGameSceneName);

        /// <summary>
        /// Called when a go to main menu button is pressed.
        /// </summary>
        static void OnGoToMainMenuButtonPressed() => LoadScene(SceneLoader.MainMenuSceneName);

        /// <summary>
        /// Tells the scene loader to load the given scene name.
        /// </summary>
        /// <param name="sceneName"></param>
        static void LoadScene(string sceneName) => SceneLoader.LoadSceneAction?.Invoke(sceneName, TransitionType.BlackFade);
    }
}
