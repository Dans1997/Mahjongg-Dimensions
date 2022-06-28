using System;
using System.Collections;
using System.Linq;
using Interfaces;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Class responsible for starting/stopping the game.
    /// </summary>
    public class GameStartManager : MonoBehaviour
    {
        /// <summary>
        /// Fired when the game is started.
        /// </summary>
        public static Action OnGameStarted { get; set; }

        /// <summary>
        /// Waits for all the game objects to be ready before starting the game.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        IEnumerator Start()
        {
            IAwaitable[] iAwaits = FindObjectsOfType<MonoBehaviour>()?.OfType<IAwaitable>().ToArray();
            if (iAwaits != null)
            {
                foreach (IAwaitable awaitable in iAwaits)
                {
                    yield return awaitable?.WaitUntilDone();
                }
            }
            
            OnGameStarted?.Invoke();
        }
    }
}