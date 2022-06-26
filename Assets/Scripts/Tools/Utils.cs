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
        /// Returns a random element from the given array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="rand"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T RandomElementUsing<T>(this T[] array, System.Random rand)
        {
            if (array == null) throw new Exception("Array is null!");
            if (rand == null) throw new Exception("Random is null!");
            return array[rand.Next(array.Length)];
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
