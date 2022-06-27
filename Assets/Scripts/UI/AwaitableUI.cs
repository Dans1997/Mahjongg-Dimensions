using System;
using System.Collections;
using Interfaces;
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
        [Header("UI References")]
        [SerializeField] Button closeButton;
        [SerializeField] bool destroyWhenDone = true;
        
        /// <summary>
        /// Shows the UI on the screen and waits for the user to click the continue button.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IEnumerator WaitUntilDone()
        {
            if (!TryGetComponent(out Canvas canvas)) throw new Exception("Canvas component not found.");
            if (!closeButton)  throw new Exception("Close button not found.");
            canvas!.enabled = true;
            closeButton.onClick?.AddListener(() => canvas.enabled = false);
            yield return new WaitUntil(() => !canvas.enabled);
            closeButton.onClick?.RemoveAllListeners();
            if (destroyWhenDone) Destroy(gameObject, 0.5f);
        }
    }
}