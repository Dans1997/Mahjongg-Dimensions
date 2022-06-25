using Tools;
using UnityEngine;

namespace Cubes
{
    /// <summary>
    /// Class responsible for building the game board.
    /// It is composed of a grid of cubes.
    /// </summary>
    public class CubeTowerBuilder : MonoBehaviour
    {
        [Header("Cube Prefab")]
        [SerializeField] GameCube cubePrefab;
        
        [Header("Possible Cube Materials")]
        [SerializeField] Material[] cubeMaterials;
        
        // Start is called before the first frame update
        void Start() => BuildGameBoard();

        /// <summary>
        /// Builds the game board.
        /// TODO: how to make sure there is always at least one valid play?
        /// </summary>
        void BuildGameBoard()
        {
            GameCube newCube = cubePrefab.CloneObject(transform.position);
            newCube.SetMaterialToEmptyRenderers(cubeMaterials.RandomElementUsing(new System.Random()));
        }
    }
}
