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
        /// Note: this is the default path. It's a fallback path if the <see cref="Cubes.CubeTowerBuilder"/> doesn't have a custom path.
        /// </summary>
        [NotNull] public const string DefaultCubeFacePath = "Default Cube Faces";
        
        /// <summary>
        /// As string based lookups are inefficient, this stores the id to the main texture of a shader.
        /// </summary>
        public static readonly int ShaderMainTextureID = Shader.PropertyToID("_MainTex");
    }
}