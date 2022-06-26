using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Tools
{
    /// <summary>
    /// Class responsible for creating objects.
    /// </summary>
    public static class ObjectFactory
    {
        /// <summary>
        /// Instantiates a prefab at the given position.
        /// </summary>
        /// <param name="prefab">The object from which to clone.</param>
        /// <param name="position">The position to clone the prefab onto.</param>
        /// <param name="rotation">The rotation to assign to the clone.</param>
        /// <param name="parent"></param>
        /// <returns></returns>
        [return: NotNull]
        public static T CloneObject<T>(this T prefab, Vector3 position = default, Quaternion rotation = default,
            Transform parent = null) where T : Object
        {
            T clone = Object.Instantiate(prefab, position, rotation, parent);
            return clone ? clone : throw new InvalidOperationException();
        }
        
        /// <summary>
        /// Destroys the given object.
        /// </summary>
        /// <param name="obj"></param>
        public static void DestroyObject<T>(this T obj) where T : Object
        {
            Object.Destroy(obj);
        }
    }
}
