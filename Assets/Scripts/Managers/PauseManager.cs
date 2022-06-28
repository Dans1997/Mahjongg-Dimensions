using System.Collections;
using Interfaces;
using Tools;
using UI;
using UI.Buttons;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Class responsible for pausing/un-pausing the game.
    /// </summary>
    public class PauseManager : MonoBehaviour
    {
        [Header("Pause UI Prefab")] 
        [SerializeField] AwaitableUI pauseUI;
        [SerializeField] AwaitableUI gameOverUI;
        
        /// <summary>
        /// Is the game currently paused? 
        /// </summary>
        static bool IsGamePaused => Time.timeScale == 0;
        
        // Start is called before the first frame update
        void Start()
        {
            PauseButton.OnPauseButtonPressed += OnPauseButtonPressed;
            GameOverManager.OnGameEnded += OnGameOver;
        }

        // OnDestroy is called when the script is destroyed
        void OnDestroy()
        {
            PauseButton.OnPauseButtonPressed -= OnPauseButtonPressed;
            GameOverManager.OnGameEnded -= OnGameOver;
            UnpauseGame();
        }

        /// <summary>
        /// Callback for when the pause button is pressed.
        /// The pause manager will pause the game, create a pause UI and wait for it to be closed.
        /// </summary>
        void OnPauseButtonPressed() => WaitForUIToUnpause(pauseUI.CloneObject(parent: transform));

        /// <summary>
        /// Callback for when the game is over.
        /// The pause manager will pause the game, create a game over UI and wait for it to be closed.
        /// </summary>
        /// <param name="endGameMessage"></param>
        void OnGameOver(string endGameMessage)
        {
            AwaitableUI newGameOverUI = gameOverUI.CloneObject(parent: transform);
            newGameOverUI.SetTitleText(endGameMessage);
            WaitForUIToUnpause(newGameOverUI);
        }

        /// <summary>
        /// Wrapper function to wait for a UI to unpause the game.
        /// </summary>
        /// <param name="uiToWait"></param>
        void WaitForUIToUnpause(IAwaitable uiToWait)
        {
            if (IsGamePaused) return;
            StartCoroutine(PauseCoroutine());
            
            IEnumerator PauseCoroutine()
            {
                PauseGame();
                yield return uiToWait?.WaitUntilDone();
                UnpauseGame();
            }
        }

        /// <summary>
        /// Pauses the game.
        /// </summary>
        static void PauseGame() => SetTimeScale(0f);
        
        /// <summary>
        /// Unpauses the game.
        /// </summary>
        static void UnpauseGame() => SetTimeScale(1f);

        /// <summary>
        /// Sets the time scale to the given value.
        /// </summary>
        /// <param name="newTimeScale"></param>
        static void SetTimeScale(float newTimeScale) => Time.timeScale = newTimeScale;
    }
}
