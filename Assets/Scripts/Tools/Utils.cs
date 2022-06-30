using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    /// <summary>
    /// Class which implements general purpose code.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Is the given array not null and not empty?
        /// </summary>
        /// <returns></returns>
        public static bool HasElements<T>(this T[] array) => array is {Length: > 0};
        
        /// <summary>
        /// Returns a random element from the given array.
        /// </summary>
        /// <param name="array"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T RandomElement<T>(this T[] array)
        {
            if (array == null) throw new Exception("Array is null!");
            return array[UnityEngine.Random.Range(0, array.Length)];
        }
        
        /// <summary>
        /// Destroys all children of a given Transform.
        /// </summary>
        /// <param name="transform"></param>
        public static void DestroyAllChildren(this Transform transform)
        {
            if (!transform) throw new Exception("Transform is null!");
            foreach (Transform child in transform)
            {
                if (!child) throw new Exception("Child is null!");
                child.gameObject.DestroyObject();
            }
        }
        
        /// <summary>
        /// Destroys all mono behaviour's objects in the stack.
        /// Important to note that this should only be called when the stack is full.
        /// </summary>
        public static void DestroyAllObjects<T>(this Stack<T> stack) where T : MonoBehaviour
        {
            if (stack == null) throw new Exception("Stack is null!");
            while (stack.Count > 0)
            {
                if (!stack.TryPop(out T pop)) continue;
                pop!.gameObject.DestroyObject();
            }
        }
    }
}
