using System.Collections;
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
        
        /// <summary>
        /// Is the game currently paused? 
        /// </summary>
        static bool IsGamePaused => Time.timeScale == 0;
        
        // Start is called before the first frame update
        void Start() => PauseButton.OnPauseButtonPressed += OnPauseButtonPressed;

        // OnDestroy is called when the script is destroyed
        void OnDestroy()
        {
            PauseButton.OnPauseButtonPressed -= OnPauseButtonPressed;
            UnpauseGame();
        }

        /// <summary>
        /// Called when the pause button is pressed.
        /// The pause manager will pause the game, create a pause UI and wait for it to be closed.
        /// </summary>
        void OnPauseButtonPressed()
        {
            if (IsGamePaused) return;
            StartCoroutine(PauseCoroutine());
            
            IEnumerator PauseCoroutine()
            {
                PauseGame();
                yield return pauseUI.CloneObject(Vector3.zero, parent: null).WaitUntilDone();
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
