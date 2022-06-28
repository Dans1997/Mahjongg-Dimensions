using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace Timers
{
    /// <summary>
    /// Class which represents a countdown timer.
    /// </summary>
    public class CountdownTimer : MonoBehaviour, ITimer
    {
        /// <summary>
        /// In this case, print how many seconds are left.
        /// </summary>
        public Action<float> OnTimerChanged { get; set; }
        
        /// <summary>
        /// Fired when the timer reaches 0.
        /// </summary>
        public Action OnTimerFinished { get; set; }

        /// <summary>
        /// Reference to the coroutine that actually counts down the time.
        /// </summary>
        Coroutine countdownCoroutine;
        
        /// <summary>
        /// Flag to stop counting down the time.
        /// </summary>
        bool isPaused;

        /// <summary>
        /// In this case, starting a coroutine will suffice.
        /// </summary>
        /// <param name="time"></param>
        /// <exception cref="Exception"></exception>
        public void StartTimer(float time)
        {
            if (countdownCoroutine != null) throw new Exception("Timer is already running.");
            countdownCoroutine = StartCoroutine(CountdownCoroutine(time));
        }

        /// <summary>
        /// Stops the timer coroutine and sets it to null so the timer can be started again in the future.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void StopTimer()
        {
            if (countdownCoroutine == null) throw new Exception("Timer is not running.");
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
        }

        /// <summary>
        /// Short way of calling StopTimer() then StartTimer() right after.
        /// </summary>S
        /// <param name="time"></param>
        /// <exception cref="Exception"></exception>
        public void ResetTimer(float time)
        {
            if (countdownCoroutine == null) throw new Exception("Timer is not running.");
            StopTimer();
            StartTimer(time);
        }

        /// <summary>
        /// In this case, stops timer without resetting its state.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void PauseTimer()
        {
            if (countdownCoroutine == null) throw new Exception("Timer is not running.");
            isPaused = true;
        }

        /// <summary>
        /// In this case, starts timer again after it was paused.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void UnpauseTimer()
        {
            if (countdownCoroutine == null) throw new Exception("Timer is not running.");
            isPaused = false;
        }
        
        /// <summary>
        /// Coroutine that counts down the time.
        /// </summary>
        /// <returns></returns>
        IEnumerator CountdownCoroutine(float time)
        {
            float timeLeft = time;
            while (timeLeft > 0)
            {
                yield return null;
                if (isPaused) continue;
                timeLeft -= Time.deltaTime;
                OnTimerChanged?.Invoke(timeLeft);
            }
            
            countdownCoroutine = null;
            OnTimerFinished?.Invoke();
        }
        
        // OnDestroy is called when the script is destroyed
        void OnDestroy()
        {
            OnTimerChanged = null;
            OnTimerFinished = null;
        }
    }
}