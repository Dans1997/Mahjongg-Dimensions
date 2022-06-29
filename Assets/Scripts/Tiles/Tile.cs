using System.Diagnostics.CodeAnalysis;
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
        
        // Start is called before the first frame update
        void Start()
        {
            Transform myTransform = transform;
            InitialPosition = myTransform.position;
            InitialScale = myTransform.localScale;
        }

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
        /// Initial position of the tile. Set on Start().
        /// </summary>
        public Vector3 InitialPosition { get; private set; }
        
        /// <summary>
        /// Initial local scale of the tile. Set on Start().
        /// </summary>
        protected Vector3 InitialScale { get; private set; }
        
        /// <summary>
        /// Public getter for the tile's model game object.
        /// </summary>
        public GameObject ModelGameObject => modelGameObject;

        /// <summary>
        /// Sets the tile's type.
        /// This will be used for matching tiles.
        /// </summary>
        /// <param name="type"></param>
        public void SetTileType(TileType type) => TileType = type;
        
        /// <summary>
        /// Sets the tile's icon
        /// Will be used to differentiate between tiles.
        /// </summary>
        /// <param name="iconTexture">Texture to be rendered by this tile.</param>
        public abstract void SetTileIcon(Texture2D iconTexture);
        
        /// <summary>
        /// The size of the tile in the game.
        /// </summary>
        public abstract float GetWorldSize();
        
        /// <summary>
        /// Returns an array with all the possible neighbours positions of this tile.
        /// </summary>
        /// <returns></returns>
        [return: NotNull]
        public abstract Vector3[] GetPossibleNeighbourPositions();

        /// <summary>
        /// Plays the tile's animation when it is clicked but can't be matched.
        /// </summary>
        public abstract void PlayNotAllowedAnimation();
    }
}