using System.Collections.Generic;
using JetBrains.Annotations;
using Tiles;

namespace Interfaces
{
    /// <summary>
    /// Interface for rules that block a match from being made.
    /// See <see cref="Tiles.ClickTileMatcher"/> for a practical example.
    /// </summary>
    public interface ITileMatcherBlocker
    {
        /// <summary>
        /// Returns true if the match is allowed to be made.
        /// </summary>
        /// <param name="clickedTile"></param>
        /// <param name="otherTiles"></param>
        /// <returns></returns>
        bool IsMatchAllowedFor(Tile clickedTile, [NotNull] Stack<Tile> otherTiles);
    }
}