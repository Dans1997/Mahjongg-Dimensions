using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Managers;
using Tools;
using UI;
using UnityEngine;

namespace Tiles
{
    /// <summary>
    /// Class which represents a tile matcher, like <see cref="ClickTileMatcher"/>.
    /// </summary>
    public abstract class TileMatcher : MonoBehaviour
    {
        /// <summary>
        /// Fired whenever a tile is matched.
        /// </summary>
        public static event System.Action<Stack<Tile>> OnMatch;

        /// <summary>
        /// Fired whenever the user fails to match a set of tiles.
        /// </summary>
        public static event System.Action OnMatchFail;
        
        /// <summary>
        /// Stack of tiles to match.
        /// </summary>
        [NotNull] public Stack<Tile> SelectedTileStack { get; protected set; } = new (0);
        
        /// <summary>
        /// Wrapper function to push a cube to stack.
        /// Created because after pushing a cube to stack, the now possibly full stack needs to destroy the cubes.
        /// </summary>
        /// <param name="cube"></param>
        protected void AddToStack(Tile cube)
        {
            SelectedTileStack.Push(cube);

            if (GameManager.GameRules.IsCollectionFull(SelectedTileStack.Count))
            {
                OnMatch?.Invoke(SelectedTileStack);
                SelectedTileStack.DestroyAllObjects();
                ClearStack();
                return;
            }
            
            TileMatcherUI.OnUpdateUI?.Invoke(SelectedTileStack);
        }
        
        /// <summary>
        /// Called when the user fails to match the clicked tiles with the other ones.
        /// </summary>
        /// <param name="clickedTile"></param>
        protected void HandleOnMatchNotAllowed(Tile clickedTile)
        {
            clickedTile!.PlayNotAllowedAnimation();
            OnMatchFail?.Invoke();
            ClearStack();
        }

        /// <summary>
        /// Wrapper function to clear the stack.
        /// Created to facilitate notifying the UI of the stack being cleared.
        /// </summary>
        protected void ClearStack()
        {
            SelectedTileStack.Clear();
            TileMatcherUI.OnUpdateUI?.Invoke(SelectedTileStack);
        }
    }
}