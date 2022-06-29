using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Managers;

namespace Tiles
{
    /// <summary>
    /// Class responsible for matching tiles when they are clicked.
    /// </summary>
    public class ClickTileMatcher : TileMatcher
    {
        // Awake is called before Start
        void Awake() => Tile.OnTileClick += HandleTileClick;
        
        // Start is called before the first frame update
        void Start() => SelectedTileStack = new Stack<Tile>(GameManager.GameRules.NumberOfTilesToMatch);

        // OnDestroy is called when the script is destroyed
        void OnDestroy()
        {
            Tile.OnTileClick -= HandleTileClick;
            ClearStack();
        }

        /// <summary>
        /// Called when a tile is clicked.
        /// This will check the tile stack and if a match is formed, destroy the tiles.
        /// </summary>
        void HandleTileClick(Tile clickedTile)
        {
            ITileMatcherBlocker[] tileMatcherBlockers = GetComponents<ITileMatcherBlocker>() ?? Array.Empty<ITileMatcherBlocker>();
            if (tileMatcherBlockers.Any(tileMatcherBlocker => !tileMatcherBlocker!.IsMatchAllowedFor(clickedTile, SelectedTileStack)))
            {
                HandleOnMatchNotAllowed();
                return;
            }
            AddToStack(clickedTile);
            
            void HandleOnMatchNotAllowed()
            {
                clickedTile!.PlayNotAllowedAnimation();
                ClearStack();
            }
        }
    }
}
