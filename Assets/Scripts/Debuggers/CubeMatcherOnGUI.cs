using System;
using Cubes;
using UnityEngine;

namespace Debuggers
{
    /// <summary>
    /// <see cref="CubeMatcher"/> GUI renderer. Used for debugging its stack.
    /// </summary>
    [RequireComponent(typeof(CubeMatcher))]
    public class CubeMatcherOnGUI : MonoBehaviour
    {
        /// <summary>
        /// Reference to the <see cref="CubeMatcher"/> component.
        /// </summary>
        CubeMatcher cubeMatcher;

        // Start is called before the first frame update
        void Start() => cubeMatcher = GetComponent<CubeMatcher>() ?? throw new InvalidOperationException();

        // OnGUI is called for rendering and handling GUI events.
        void OnGUI()
        {
            if (!cubeMatcher) return;
            if (cubeMatcher.SelectedCubeStack.Count <= 0)
            {
                GUI.Label(new Rect(10, 30, 100, 20), "Stack is empty!");
                return;
            }

            // Draw Each Cube Type From The Stack
            int i = 0;
            foreach (Cube cube in cubeMatcher.SelectedCubeStack)
            {
                if (!cube) throw new InvalidOperationException();
                GUI.Label(new Rect(10, 30 + i * 20, 100, 20), cube.CubeType.ToString());
                i++;
            }
        }
    }
}