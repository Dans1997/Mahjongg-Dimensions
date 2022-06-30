using System;
using System.Collections.Generic;
using Interfaces;
using Tiles;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Class which manages the game's score.
    /// They listen to <see cref="Tiles.TileMatcher"/>s' events to count points.
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        /// <summary>
        /// Fired whenever the score changes.
        /// Used mostly for UI.
        /// </summary>
        public static event Action<int> OnScoreChanged;
        
        /// <summary>
        /// Current score of the game.
        /// </summary>
        public static int CurrentScore { get; private set; }
        
        // Start is called before the first frame update
        void Start()
        {
            GameStartManager.OnGameStarted += ResetScore;
            GameOverManager.OnGameEnded += HandleOnGameEnded;
            TileMatcher.OnMatch += OnMatch;
        }
        
        // OnDestroy is called when the script is destroyed
        void OnDestroy()
        {
            GameStartManager.OnGameStarted -= ResetScore;
            GameOverManager.OnGameEnded -= HandleOnGameEnded;
            TileMatcher.OnMatch -= OnMatch;
        }

        /// <summary>
        /// Resets the score back to zero.
        /// </summary>
        static void ResetScore() => CurrentScore = 0;

        /// <summary>
        /// Callback for when the game is over.
        /// Will stop listening for matches to avoid changing the value post-game.
        /// </summary>
        /// <param name="_"></param>
        void HandleOnGameEnded(string _)
        {
            OnScoreChanged?.Invoke(CurrentScore);
            TileMatcher.OnMatch -= OnMatch;
        }

        /// <summary>
        /// Callback for when a match is made.
        /// </summary>
        void OnMatch(Stack<Tile> _)
        {
            int scoreToAdd = GameManager.GameRules.BasePointsForEachMatch;
            
            ITileMatcherMultiplier[] multipliers = GetComponents<ITileMatcherMultiplier>() ?? Array.Empty<ITileMatcherMultiplier>();
            foreach (ITileMatcherMultiplier multiplier in multipliers) multiplier!.ChangeScore(ref scoreToAdd);
            
            CurrentScore += scoreToAdd;
            OnScoreChanged?.Invoke(CurrentScore);
        }
    }
}