using UnityEngine;

namespace Cubes
{
    /// <summary>
    /// Class which represents a cube in the game.
    /// </summary>
    public abstract class Cube : MonoBehaviour
    {
        [Header("Cube Faces Renderers")]
        [SerializeField] protected MeshRenderer[] quadRenderers = new MeshRenderer[6];
        
        /// <summary>
        /// Assigns the given material to all the mesh renderers of the cube that do not have a material assigned.
        /// </summary>
        /// <param name="material">The material to assign to the empty mesh renderers.</param>
        public void SetMaterialToAllFaces(Material material)
        {
            foreach (MeshRenderer quadRenderer in quadRenderers)
            {
                quadRenderer.material = material;
            }
        }
    }
}