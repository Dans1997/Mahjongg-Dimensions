﻿using Managers;
using UnityEngine;

namespace UI.ManagerDependant
{
    /// <summary>
    /// Class responsible for handling the timer display in the game.
    /// </summary>
    public class TimerUI : ManagerDependantUI
    {
        /// <summary>
        /// Sub to the score manager's score changed event.
        /// </summary>
        protected override void SubToManager() => TimerManager.OnTimerChanged += OnTimerChanged;

        /// <summary>
        /// Unsub from the score manager's score changed event.
        /// </summary>
        protected override void UnsubFromManager() => TimerManager.OnTimerChanged -= OnTimerChanged;
        
        /// <summary>
        /// Callback for when the timer changes its value.
        /// </summary>
        /// <param name="timerValueInSeconds"></param>
        void OnTimerChanged(float timerValueInSeconds)
        {
            string minutes = Mathf.FloorToInt(timerValueInSeconds / 60).ToString("00");
            string seconds = Mathf.CeilToInt(timerValueInSeconds % 60).ToString("00");
            TextReference!.text = $"{minutes}:{seconds}";
        }
    }
}