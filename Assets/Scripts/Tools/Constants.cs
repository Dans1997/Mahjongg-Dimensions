using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Tools
{
    /// <summary>
    /// Class which holds frequently used values.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Path used to load all possible cube faces in the game.
        /// Note: this is a fallback path for the <see cref="Cubes.CubeTowerBuilder"/>.
        /// </summary>
        [NotNull] public const string DefaultCubeFacePath = "Default Cube Faces";
        
        /// <summary>
        /// Path used to load all possible scene transitions in the game.
        /// Note: this is a fallback path for the <see cref="Managers.SceneLoader"/>.
        /// </summary>
        [NotNull] public const string DefaultCSceneTransitionPath = "Transitions";
        
        /// <summary>
        /// As string based lookups are inefficient, this stores the id to the main texture of a shader.
        /// </summary>
        public static readonly int ShaderMainTextureID = Shader.PropertyToID("_MainTex");
    }
}