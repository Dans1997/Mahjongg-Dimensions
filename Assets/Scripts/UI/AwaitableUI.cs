using System;
using System.Collections;
using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Class which represents screens that need to be waited for to be closed.
    /// Example, tutorial UI, pause UI, etc.
    /// </summary>
    public abstract class AwaitableUI : MonoBehaviour, IAwaitable
    {
        [Header("General")]
        [SerializeField] bool destroyWhenDone = true;
        
        [Header("UI References")]
        [SerializeField] Button[] closeButtons;
        [SerializeField] TMP_Text titleText;

        /// <summary>
        /// Shows the UI on the screen and waits for the user to click the continue button.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IEnumerator WaitUntilDone()
        {
            if (!TryGetComponent(out Canvas canvas)) throw new Exception("Canvas component not found.");
            if (closeButtons == null)  throw new Exception("Close button not found.");
            canvas!.enabled = true;

            foreach (Button button in closeButtons) button!.onClick?.AddListener(CloseCanvas);
            yield return new WaitUntil(() => !canvas.enabled);
            foreach (Button button in closeButtons) button!.onClick?.RemoveListener(CloseCanvas);
            if (destroyWhenDone) Destroy(gameObject, 0.5f);
            
            void CloseCanvas() => canvas.enabled = false;
        }

        /// <summary>
        /// Sets the text of the title.
        /// </summary>
        public void SetTitleText(string newText)
        {
            if (titleText == null) return;
            titleText.text = newText;
        }
    }
}