using System;
using General;
using Tiles;
using UI.Buttons;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Class responsible for managing the game board's rotation.
    /// </summary>
    public class TileRotationManager : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] float rotationAngle = 45f;
        
        [SerializeField] RotationButton leftRotationButton;
        [SerializeField] RotationButton rightRotationButton;

        /// <summary>
        /// Reference to the scenes <see cref="Tiles.TileBuilder"/>'s rotator component.
        /// </summary>
        DragRotator gameBoardDragRotator;
        
        // Awake is called before Start
        void Awake()
        {
            gameBoardDragRotator = FindObjectOfType<TileBuilder>()?.GetComponent<DragRotator>();
            if (!gameBoardDragRotator) throw new Exception("Missing tile builder!");
            gameBoardDragRotator.SetDragEnabled(false);
        }
        
        // Start is called before the first frame update
        void Start()
        {
            GameStartManager.OnGameStarted += OnGameStarted;
            TileBuilder.OnAllTilesBuilt += OnTilesBuilt;

            if (!leftRotationButton || !rightRotationButton) throw new Exception("Missing rotation buttons!");
            leftRotationButton.OnRotationButtonClicked += OnLeftRotationButtonClick;
            rightRotationButton.OnRotationButtonClicked += OnRightRotationButtonClick;
        }

        // OnDestroy is called when the script is destroyed
        void OnDestroy()
        {
            GameStartManager.OnGameStarted -= OnGameStarted;
            TileBuilder.OnAllTilesBuilt -= OnTilesBuilt;

            if (leftRotationButton != null) leftRotationButton.OnRotationButtonClicked -= OnLeftRotationButtonClick;
            if (rightRotationButton != null) rightRotationButton.OnRotationButtonClicked -= OnRightRotationButtonClick;
        }

        /// <summary>
        /// Callback for when the game starts.
        /// </summary>
        void OnGameStarted()
        {
            if (gameBoardDragRotator == null) throw new Exception("Rotator component is null.");
            gameBoardDragRotator.SetDragEnabled(true);
        }

        /// <summary>
        /// Callback for when the game board is built.
        /// </summary>
        void OnTilesBuilt()
        {
            if (gameBoardDragRotator == null) throw new Exception("Rotator component is null.");
            gameBoardDragRotator.CalculateCentroid();
        }

        /// <summary>
        /// Callback for when the LEFT rotation button is clicked.
        /// </summary>
        void OnLeftRotationButtonClick()
        {
            if (gameBoardDragRotator == null) throw new Exception("Rotator component is null.");
            gameBoardDragRotator.AutoRotateBy(-rotationAngle);
        }

        /// <summary>
        /// Callback for when the RIGHT rotation button is clicked.
        /// </summary>
        void OnRightRotationButtonClick()
        {
            if (gameBoardDragRotator == null) throw new Exception("Rotator component is null.");
            gameBoardDragRotator.AutoRotateBy(rotationAngle);
        }
    }
}