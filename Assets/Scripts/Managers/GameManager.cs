using Cubes;
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
        /// </summary>
        public static GameRules GameRules = new (2);

        /// <summary>
        /// Has OnApplicationQuit been called?
        /// </summary>
        public static bool WillApplicationQuit { get; private set; }

        /// <summary>
        /// Called when the application is quitting.
        /// </summary>
        void OnApplicationQuit() => WillApplicationQuit = true;
    }
}