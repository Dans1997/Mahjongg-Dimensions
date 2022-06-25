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
    }
}