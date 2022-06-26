using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Class responsible for dealing with the tutorial UI.
    /// It has different pages that are shown to the user.
    /// Note: handling pages could be later decoupled from this class.
    /// </summary>
    public class StartTutorialUI : MonoBehaviour, IAwaitable
    {
        [Header("UI References")] 
        [SerializeField] [NotNull] RectTransform[] pages = Array.Empty<RectTransform>();
        
        [Header("UI References")]
        [SerializeField] Button previousButton;
        [SerializeField] Button nextButton;
        [SerializeField] Button continueButton;
        
        [Header("UI References")]
        [SerializeField] int currentPageIndex;
        
        // Start is called before the first frame update
        void Start()
        {
            if (previousButton) previousButton.onClick?.AddListener(PreviousPage);
            if (nextButton) nextButton.onClick?.AddListener(NextPage);
            ShowPageIndex(currentPageIndex);
        }

        /// <summary>
        /// Goes to the next page.
        /// </summary>
        void NextPage()
        {
            if (currentPageIndex >= pages.Length - 1) return;
            ShowPageIndex(currentPageIndex + 1);
        }

        /// <summary>
        /// Goes to the previous page.
        /// </summary>
        void PreviousPage()
        {
            if (currentPageIndex <= 0) return;
            ShowPageIndex(currentPageIndex - 1);
        }

        /// <summary>
        /// Activates the page with the given index while deactivating the other ones.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void ShowPageIndex(int pageIndex)
        {
            foreach (RectTransform page in pages)
            {
                if (page) page.gameObject.SetActive(false);
            }
            
            pages[pageIndex]?.gameObject.SetActive(true);
            currentPageIndex = pageIndex;
        }

        /// <summary>
        /// Shows the UI on the screen and waits for the user to click the continue button.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IEnumerator WaitUntilDone()
        {
            if (!TryGetComponent(out Canvas canvas)) throw new Exception("Canvas component not found.");
            if (!continueButton)  throw new Exception("Canvas component not found.");
            canvas!.enabled = true;
            continueButton.onClick?.AddListener(() => canvas.enabled = false);
            yield return new WaitUntil(() => !canvas.enabled);
            continueButton.onClick?.RemoveAllListeners();
        }
    }
}