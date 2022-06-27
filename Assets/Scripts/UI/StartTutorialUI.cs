using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Class responsible for dealing with the tutorial UI.
    /// It has different pages that are shown to the user.
    /// Note: handling pages could be later decoupled from this class.
    /// </summary>
    public class StartTutorialUI : AwaitableUI
    {
        [Header("Page Settings")]
        [SerializeField] [NotNull] RectTransform[] pages = Array.Empty<RectTransform>();
        [SerializeField] Button previousButton;
        [SerializeField] Button nextButton;
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
    }
}