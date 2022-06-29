using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Tiles;
using UnityEngine;

namespace MatcherBlockers
{
    /// <summary>
    /// Class that only allows certain kinds of tiles to be selected.
    /// </summary>
    public class OneXZNeighbourMatcherBlocker : MonoBehaviour, ITileMatcherBlocker
    {
        /// <summary>
        /// Based on the given tile, will calculate the number of neighbours in each horizontal direction
        /// and check if they exist.
        /// </summary>
        /// <param name="clickedTile"></param>
        /// <param name="otherTiles"></param>
        /// <returns></returns>
        public bool IsMatchAllowedFor(Tile clickedTile, Stack<Tile> otherTiles)
        {
            if (!clickedTile) throw new Exception("Tile is null");

            Dictionary<Vector3, Tile> tiles = TileBuilder.BuiltTiles;
            if (tiles == null) throw new Exception("This should not happen. No game board found!");
            if (!tiles.ContainsValue(clickedTile)) return false;
            
            // Get Possible Neighbours
            Vector3[] possibleNeighbourPositions = clickedTile.GetPossibleNeighbourPositions();

            // Count Number of Neighbours That Have Same X Coordinate
            int xNeighbours = possibleNeighbourPositions
                .Where(p => tiles.ContainsKey(p) && tiles[p] != null)
                .Count(p => Math.Sqrt(p.x - clickedTile.InitialPosition.x) < 0.1f);
            
            // Count Number of Neighbours That Have Same Z Coordinate
            int zNeighbours = possibleNeighbourPositions
                .Where(p => tiles.ContainsKey(p) && tiles[p] != null)
                .Count(p => Math.Abs(p.z - clickedTile.InitialPosition.z) < 0.1f);
            
            Debug.Log($"X: {xNeighbours} Z: {zNeighbours}");
            return xNeighbours <= 1 && zNeighbours <= 1;
        }
    }
}