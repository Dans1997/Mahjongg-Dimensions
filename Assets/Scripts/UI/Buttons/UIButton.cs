using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    /// <summary>
    /// Class that represents a button in the UI.
    /// Created to decouple the UI from the game logic.
    /// </summary>
    public abstract class UIButton : Button
    {
        [Header("Other Settings")]
        [SerializeField] bool becomeInactiveOnClick = true;
        
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            interactable = true;
            onClick?.AddListener(OnClick);
        }
        
        /// <summary>
        /// Turn off the button when it is clicked to prevent it from being clicked again.
        /// </summary>
        void OnClick()
        {
            ProcessClick();
            if (becomeInactiveOnClick) interactable = false;
        }
        
        /// <summary>
        /// Called when the button is clicked.
        /// </summary>
        protected abstract void ProcessClick();
    }
}
