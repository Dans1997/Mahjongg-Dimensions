using UnityEngine;

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
        /// <returns></returns>
        public static T CloneObject<T>(this T prefab, Vector3 position, Quaternion rotation = default) where T : MonoBehaviour
        {
            T clone = Object.Instantiate(prefab, position, rotation);
            return clone;
        }
    }
}
