using System.Collections.Generic;
using Interfaces;
using Tiles;
using UnityEngine;

namespace MatcherBlockers
{
    /// <summary>
    /// Player can click on two tiles tiles with the same sprite/colour (here, represented by its type).
    /// </summary>
    public class SameTypeTileMatcherBlocker : MonoBehaviour, ITileMatcherBlocker
    {
        /// <summary>
        /// Validates two tiles to see if they match.
        /// </summary>
        /// <param name="clickedTile"></param>
        /// <param name="otherTiles"></param>
        /// <returns></returns>
        public bool IsMatchAllowedFor(Tile clickedTile, Stack<Tile> otherTiles)
        {
            otherTiles.TryPeek(out Tile peekedTile);
            if (!clickedTile) throw new System.Exception("Clicked tile is null.");
            if (!peekedTile) return true;
            if (peekedTile == clickedTile) return false;
            return clickedTile.TileType == peekedTile.TileType;
        }
    }
}