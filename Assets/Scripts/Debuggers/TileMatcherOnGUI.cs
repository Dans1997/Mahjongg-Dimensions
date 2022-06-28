using System;
using Tiles;
using UnityEngine;

namespace Debuggers
{
    /// <summary>
    /// <see cref="TileMatcher"/>'s GUI renderer. Used for debugging its stack.
    /// </summary>
    [RequireComponent(typeof(TileMatcher))]
    public class TileMatcherOnGUI : MonoBehaviour
    {
        /// <summary>
        /// Reference to the <see cref="TileMatcher"/> component.
        /// </summary>
        TileMatcher tileMatcher;

        // Start is called before the first frame update
        void Start() => tileMatcher = GetComponent<TileMatcher>() ?? throw new InvalidOperationException();

        // OnGUI is called for rendering and handling GUI events.
        void OnGUI()
        {
            if (!tileMatcher) return;
            if (tileMatcher.SelectedTileStack.Count <= 0)
            {
                GUI.Label(new Rect(10, 30, 100, 20), "Stack is empty!");
                return;
            }

            // Draw Each Tile Type From The Stack
            int i = 0;
            foreach (Tile tile in tileMatcher.SelectedTileStack)
            {
                if (!tile) throw new InvalidOperationException();
                GUI.Label(new Rect(10, 30 + i * 20, 100, 20), tile.TileType.ToString());
                i++;
            }
        }
    }
}