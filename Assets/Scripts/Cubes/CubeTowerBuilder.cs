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
        [SerializeField] Cube cubePrefab;

        // Start is called before the first frame update
        void Start() => BuildGameBoard();

        /// <summary>
        /// Builds the game board.
        /// TODO: how to make sure there is always at least one valid play?
        /// </summary>
        void BuildGameBoard(string cubeFacePath = null)
        {
            Cube newCube = cubePrefab.CloneObject(transform.position);

            // Load all the cube faces from the resources folder.
            Texture2D[] cubeFaces = Resources.LoadAll<Texture2D>(string.IsNullOrEmpty(cubeFacePath)
                ? Constants.DefaultCubeFacePath
                : cubeFacePath);

            // Pick Random Value From Cube Type Enum
            GameCubeType cubeType = (GameCubeType) Random.Range(0, System.Enum.GetValues(typeof(GameCubeType)).Length);
            
            // Find The Cube FACE that matches the cube type.
            newCube.SetCubeType(cubeType);
            newCube.SetCubeIcon(cubeFaces[(int)cubeType]);
        }
    }
}
