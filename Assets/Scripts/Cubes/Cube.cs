using System;
using System.Diagnostics.CodeAnalysis;
using Managers;
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
        [SerializeField] protected GameCubeType cubeType = GameCubeType.Buttons;
        
        [Header("Renderers")]
        [Tooltip("The game object which contains all the renderers of this cube.")]
        [SerializeField] GameObject modelGameObject;
        
        [Header("Cube Faces")]
        [SerializeField] [NotNull] protected MeshRenderer[] quadRenderers = new MeshRenderer[6];

        /// <summary>
        /// Public property for the cube type.
        /// </summary>
        public GameCubeType CubeType => cubeType;
        
        /// <summary>
        /// Public property for the cube's model game object.
        /// </summary>
        public GameObject ModelGameObject => modelGameObject;
        
        /// <summary>
        /// Sets the cube type.
        /// </summary>
        /// <param name="type"></param>
        public void SetCubeType(GameCubeType type) => cubeType = type;

        /// <summary>
        /// The size of the cube in world units.
        /// </summary>
        public abstract float GetWorldCubeSize();
        
        /// <summary>
        /// Assigns the given material to all the mesh renderers of the cube that do not have a material assigned.
        /// </summary>
        /// <param name="iconTexture">The material to assign to the empty mesh renderers.</param>
        public void SetCubeIcon(Texture2D iconTexture)
        {
            foreach (MeshRenderer quadRenderer in quadRenderers)
            {
                if (quadRenderer == null) throw new InvalidOperationException("The quad renderer is null.");
                if (quadRenderer.material == null) throw new InvalidOperationException("The quad renderer material is null.");
                quadRenderer.material.SetTexture(Constants.ShaderMainTextureID, iconTexture);
            }
        }
        
        /// <summary>
        /// When a cube is destroyed, it is replaced by a dummy cube that plays a destruction animation.
        /// For visual purposes.
        /// </summary>
        void OnDestroy()
        {
            if (GameStateManager.CurrentGameState != GameStateManager.GameState.Game) return;

            Transform myTransform = transform;
            GameObject dummyCube = modelGameObject.CloneObject(myTransform.position, parent: myTransform.parent);
            dummyCube.AddComponent<CubeDestructionHandler>();
        }
    }
}