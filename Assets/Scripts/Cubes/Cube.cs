using Tools;
using UnityEngine;

namespace Cubes
{
    /// <summary>
    /// Class which represents a cube in the game.
    /// </summary>
    public abstract class Cube : MonoBehaviour
    {
        [Header("General")]
        [Tooltip("Serialized for testing. No need to change this, as it is automatically set.")]
        [SerializeField] GameCubeType cubeType = GameCubeType.Buttons;
        
        [Header("Cube Faces Renderers")]
        [SerializeField] protected MeshRenderer[] quadRenderers = new MeshRenderer[6];

        /// <summary>
        /// Sets the cube type.
        /// </summary>
        /// <param name="type"></param>
        public void SetCubeType(GameCubeType type) => cubeType = type;
        
        /// <summary>
        /// Assigns the given material to all the mesh renderers of the cube that do not have a material assigned.
        /// </summary>
        /// <param name="iconTexture">The material to assign to the empty mesh renderers.</param>
        public void SetCubeIcon(Texture2D iconTexture)
        {
            foreach (MeshRenderer quadRenderer in quadRenderers)
            {
                quadRenderer.material.SetTexture(Constants.ShaderMainTextureID, iconTexture);
            }
        }
    }
}