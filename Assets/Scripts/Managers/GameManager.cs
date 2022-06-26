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
        /// Note: these default values are taken from the assignment document.
        /// </summary>
        public static GameRules GameRules = new (2, new Vector3(4,4,4), 100, 6);

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
