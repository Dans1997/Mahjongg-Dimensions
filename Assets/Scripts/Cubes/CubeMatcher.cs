using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Managers;
using UnityEngine;
using Tools;

namespace Cubes
{
    /// <summary>
    /// Class responsible for matching cubes.
    /// </summary>
    public class CubeMatcher : MonoBehaviour
    {
        /// <summary>
        /// Stack of cubes to match.
        /// </summary>
        [NotNull] internal Stack<Cube> SelectedCubeStack { get; private set; } = new (0);

        // Awake is called before Start
        void Awake() => GameCube.OnCubeClick += HandleOnCubeClick;
        
        // Start is called before the first frame update
        void Start() => SelectedCubeStack = new Stack<Cube>(GameManager.GameRules.NumberOfCubesToMatch);

        // OnDestroy is called when the script is destroyed
        void OnDestroy()
        {
            GameCube.OnCubeClick -= HandleOnCubeClick;
            SelectedCubeStack.Clear();
        }

        /// <summary>
        /// Called when a cube is clicked.
        /// This will check the cube stack and if a match is formed, destroy the cubes.
        /// </summary>
        void HandleOnCubeClick(Cube clickedCube)
        {
            SelectedCubeStack.TryPeek(out Cube peekedCube);
            if (!GameRules.DoCubesMatch(clickedCube, peekedCube)) SelectedCubeStack.Clear();
            AddToStack(clickedCube);
        }

        /// <summary>
        /// Wrapper function to push a cube to stack.
        /// Created because after pushing a cube to stack, the now possibly full stack needs to destroy the cubes.
        /// </summary>
        /// <param name="cube"></param>
        void AddToStack(Cube cube)
        {
            SelectedCubeStack.Push(cube);
            if (!GameManager.GameRules.IsCollectionFull(SelectedCubeStack.Count)) return;
            SelectedCubeStack.DestroyAllObjects();
        }
    }
}
