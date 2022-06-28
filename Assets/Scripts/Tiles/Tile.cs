using UnityEngine;

namespace Tiles
{
    /// <summary>
    /// Class which represents a tile in the game, like the <see cref="Cubes.Cube"/>.
    /// </summary>
    public abstract class Tile : MonoBehaviour
    {
        [Header("Renderers")]
        [Tooltip("The game object which contains all the renderers of this tile.")]
        [SerializeField] protected GameObject modelGameObject;

        /// <summary>
        /// Fired whenever this cube is clicked on.
        /// </summary>
        public static System.Action<Tile> OnTileClick { get; set; }
        
        /// <summary>
        /// Type of the tile.
        /// For <see cref="Cubes.Cube"/>s, this means the type of icon it shows.
        /// </summary>
        public TileType TileType { get; private set; } = TileType.Buttons;
        
        /// <summary>
        /// Public getter for the tile's model game object.
        /// </summary>
        public GameObject ModelGameObject => modelGameObject;

        /// <summary>
        /// Sets the cube type.
        /// </summary>
        /// <param name="type"></param>
        public void SetTileType(TileType type) => TileType = type;
        
        /// <summary>
        /// The size of the tile in the game.
        /// </summary>
        public abstract float GetWorldSize();
    }
}