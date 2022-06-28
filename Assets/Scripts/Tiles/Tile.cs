using UnityEngine;

namespace Tiles
{
    /// <summary>
    /// Class which represents a tile in the game, like the <see cref="Cubes.Cube"/>.
    /// </summary>
    public abstract class Tile : MonoBehaviour
    {
        /// <summary>
        /// The size of the tile in the game.
        /// </summary>
        public abstract float GetWorldSize();
    }
}