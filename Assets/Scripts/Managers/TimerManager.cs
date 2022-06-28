using System;
using Interfaces;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Class responsible for managing the timer of the game.
    /// </summary>
    [RequireComponent(typeof(ITimer))]
    public class TimerManager : MonoBehaviour
    {
        /// <summary>
        /// Called when timer changes its value.
        /// </summary>
        public static Action<float> OnTimerChanged { get; set; }
        
        /// <summary>
        /// Called when timer ends.
        /// </summary>
        public static Action OnTimeOut { get; set; }

        // Start is called before the first frame update
        void Start() => GameStartManager.OnGameStarted += OnGameStarted;

        // OnDestroy is called when the script is destroyed
        void OnDestroy() => GameStartManager.OnGameStarted -= OnGameStarted;

        /// <summary>
        /// Callback when game starts.
        /// </summary>
        void OnGameStarted()
        {
            if (!TryGetComponent(out ITimer timer))
            {
                throw new Exception("TimerManager must be attached to a GameObject with a ITimer component.");
            }
            
            timer!.StartTimer(GameManager.GameRules.TimeLimitInSeconds);
            timer.OnTimerChanged += HandleOnTimerChanged;
            timer.OnTimerFinished += OnTimerFinished;
        }

        /// <summary>
        /// Callback for when timer value changes.
        /// </summary>
        /// <param name="timerValueInSeconds"></param>
        static void HandleOnTimerChanged(float timerValueInSeconds) => OnTimerChanged?.Invoke(timerValueInSeconds);

        /// <summary>
        /// Callback for when the timer finishes.
        /// </summary>
        static void OnTimerFinished() => OnTimeOut?.Invoke();
    }
}