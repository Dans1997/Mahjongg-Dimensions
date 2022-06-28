using System;
using Managers;
using TMPro;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Class responsible for handling the timer display in the game.
    /// </summary>
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] TMP_Text timerText;
        
        // Awake is called before Start
        void Awake()
        {
            if (timerText) return;
            throw new Exception("Timer text reference is null!");
        }

        // Start is called before the first frame update
        void Start()
        {
            TimerManager.OnTimerChanged += OnTimerChanged;
            GameOverManager.OnGameOver += OnGameOver;
        }

        // OnDestroy is called when the script is destroyed
        void OnDestroy()
        {
            TimerManager.OnTimerChanged -= OnTimerChanged;
            GameOverManager.OnGameOver -= OnGameOver;
        }
        
        /// <summary>
        /// Callback for when the game ends
        /// </summary>
        /// <param name="endMessage"></param>
        void OnGameOver(string endMessage)
        {
            TimerManager.OnTimerChanged -= OnTimerChanged;
            timerText!.text = "00:00";
        }

        /// <summary>
        /// Callback for when the timer changes its value.
        /// </summary>
        /// <param name="timerValueInSeconds"></param>
        void OnTimerChanged(float timerValueInSeconds)
        {
            string minutes = Mathf.FloorToInt(timerValueInSeconds / 60).ToString("00");
            string seconds = Mathf.CeilToInt(timerValueInSeconds % 60).ToString("00");
            timerText!.text = $"{minutes}:{seconds}";
        }
    }
}