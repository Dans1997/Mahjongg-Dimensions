using Managers;
using TMPro;
using UnityEngine;

namespace UI.ManagerDependant
{
    /// <summary>
    /// Class which represent UI that depends on managers to display their values.
    /// See, for instance, <see cref="ScoreUI"/> and <see cref="TimerUI"/>.
    /// </summary>
    [RequireComponent(typeof(TMP_Text))]
    public abstract class ManagerDependantUI : MonoBehaviour
    {
        /// <summary>
        /// Reference to the text that needs to be updated by this behaviour.
        /// </summary>
        protected TMP_Text TextReference;
        
        // Awake is called before Start
        void Awake()
        {
            if (TryGetComponent(out TextReference)) return;
            throw new System.Exception("Text reference is null!");
        }

        // Start is called before the first frame update
        void Start()
        {
            SubToManager();
            GameOverManager.OnGameEnded += OnGameOver;
        }

        // OnDestroy is called when the script is destroyed
        void OnDestroy()
        {
            UnsubFromManager();
            GameOverManager.OnGameEnded -= OnGameOver;
        }
        
        /// <summary>
        /// Called to receive value update from <see cref="Managers"/>.
        /// </summary>
        protected abstract void SubToManager();

        /// <summary>
        /// Called when text value not longer needs to be updated.
        /// </summary>
        protected abstract void UnsubFromManager();

        /// <summary>
        /// Callback for when the game ends
        /// </summary>
        /// <param name="endMessage"></param>
        protected virtual void OnGameOver(string endMessage)
        {
            UnsubFromManager();
        }
    }
}