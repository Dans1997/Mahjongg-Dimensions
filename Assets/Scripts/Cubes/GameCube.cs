using System;
using Tools;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cubes
{
    /// <summary>
    /// Class that represents a cube in the game.
    /// </summary>
    [RequireComponent(typeof(BoxCollider))]
    public class GameCube : Cube, IPointerClickHandler
    {
        [SerializeField] float shakeDuration = 0.25f;

        /// <summary>
        /// Reference to the coroutine that shakes a tile if is fails to be selected.
        /// </summary>
        Coroutine shakeCoroutine;
        
        /// <summary>
        /// Since there's a box collider on the cube, the world size of the cube is the size of the box collider.
        /// </summary>
        public override float GetWorldSize()
        {
            if (!TryGetComponent(out BoxCollider boxCollider)) throw new Exception("Box collider not found on cube.");
            return boxCollider!.size.x;
        }
        
        /// <summary>
        /// Returns all the HORIZONTAL neighbors of the cube.
        /// Cubes can only be pressed if they have mostly one neighbour in each horizontal direction.
        /// Up and down cubes don’t interfere.
        /// </summary>
        /// <returns></returns>
        public override Vector3[] GetPossibleNeighbourPositions()
        {
            Vector3[] possibleNeighbourPositions = new Vector3[4];
            float myWorldSize = GetWorldSize();
            possibleNeighbourPositions[0] = InitialPosition + new Vector3(1, 0, 0) * myWorldSize;
            possibleNeighbourPositions[1] = InitialPosition + new Vector3(-1, 0, 0) * myWorldSize;
            possibleNeighbourPositions[2] = InitialPosition + new Vector3(0, 0, 1) * myWorldSize;
            possibleNeighbourPositions[3] = InitialPosition + new Vector3(0, 0, -1) * myWorldSize;
            return possibleNeighbourPositions;
        }

        /// <summary>
        /// For now, the animation is a simple shake.
        /// </summary>
        public override void PlayNotAllowedAnimation()
        {
            if (shakeCoroutine != null) StopCoroutine(shakeCoroutine);
            shakeCoroutine = StartCoroutine(transform.ShakeFor(InitialScale, shakeDuration));
        }

        /// <summary>
        /// Called if a click occurs on this cube.
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"Clicked on cube {TileType}.");
            OnTileClick?.Invoke(this);
        }
    }
}
