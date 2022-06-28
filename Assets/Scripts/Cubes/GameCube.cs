using System;
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
        /// <summary>
        /// Fired whenever this cube is clicked on.
        /// </summary>
        public static Action<GameCube> OnCubeClick { get; set; }

        /// <summary>
        /// Since there's a box collider on the cube, the world size of the cube is the size of the box collider.
        /// </summary>
        public override float GetWorldSize()
        {
            if (!TryGetComponent(out BoxCollider boxCollider)) throw new Exception("Box collider not found on cube.");
            return boxCollider!.size.x;
        }
        
        /// <summary>
        /// Called if a click occurs on this cube.
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"Clicked on cube {cubeType}.");
            OnCubeClick?.Invoke(this);
        }
    }
}
