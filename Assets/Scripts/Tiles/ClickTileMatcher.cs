using System.Collections.Generic;
using Managers;

namespace Tiles
{
    /// <summary>
    /// Class responsible for matching tiles when they are clicked.
    /// </summary>
    public class ClickTileMatcher : TileMatcher
    {
        // Awake is called before Start
        void Awake() => Tile.OnTileClick += HandleOnCubeClick;
        
        // Start is called before the first frame update
        void Start() => SelectedTileStack = new Stack<Tile>(GameManager.GameRules.NumberOfTilesToMatch);

        // OnDestroy is called when the script is destroyed
        void OnDestroy()
        {
            Tile.OnTileClick -= HandleOnCubeClick;
            ClearStack();
        }

        /// <summary>
        /// Called when a cube is clicked.
        /// This will check the cube stack and if a match is formed, destroy the cubes.
        /// </summary>
        void HandleOnCubeClick(Tile clickedCube)
        {
            SelectedTileStack.TryPeek(out Tile peekedCube);
            if (!GameRules.DoTilesMatch(clickedCube, peekedCube)) ClearStack();
            AddToStack(clickedCube);
        }
    }
}
