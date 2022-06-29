using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Cubes;
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
        public static event System.Action OnMatch;
        
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
                SelectedTileStack.DestroyAllObjects();
                ClearStack();
                OnMatch?.Invoke();
                return;
            }
            
            TileMatcherUI.OnUpdateUI?.Invoke(SelectedTileStack);
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