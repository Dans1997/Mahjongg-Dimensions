using System;
using System.Linq;
using Managers;
using Tiles;
using Tools;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Cubes
{
    /// <summary>
    /// Class responsible for building the game board.
    /// It is composed of a grid of cubes.
    /// </summary>
    public class CubeTowerBuilder : TileBuilder
    {
        [Header("Cube Prefab")]
        [SerializeField] protected Cube cubePrefab;
        
        /// <summary>
        /// In this case, builds a tower following the <see cref="Managers.GameManager.GameRules"/>.
        /// </summary>
        public override void BuildGameBoard()
        {
            BuildCubeTower(gridDimensions: GameManager.GameRules.GameBoardDimensions);
            OnAllTilesBuilt?.Invoke();
        }
        
        /// <summary>
        /// Builds the game board.
        /// TODO: how to make sure there is always at least one valid play?
        /// </summary>
        /// <param name="cubeFacePath">Resources folder path to load game piece faces.</param>
        /// <param name="gridDimensions"></param>
        void BuildCubeTower(string cubeFacePath = null, Vector3 gridDimensions = default)
        {
            Texture2D[] cubeFaces = Resources.LoadAll<Texture2D>(string.IsNullOrEmpty(cubeFacePath)
                ? Constants.DefaultCubeFacePath
                : cubeFacePath);
            
            if (cubeFaces == null) throw new Exception("Could not load cube faces from resources.");
            if (!cubePrefab) throw new Exception("Cube prefab is null.");

            int numberOfPossibleTypes = GameManager.GameRules.NumberOfPossibleTileTypes;
            System.Random rnd = new ();
            cubeFaces = cubeFaces.OrderBy(_ => rnd.Next()).Take(numberOfPossibleTypes).ToArray();
            float sizeMultiplier = cubePrefab.GetWorldSize();

            // Create a 3D Cube Grid
            for (int z = 0; z < gridDimensions.z; z++)
            {
                for (int y = 0; y < gridDimensions.y; y++)
                {
                    for (int x = 0; x < gridDimensions.x; x++)
                    {
                        TileType cubeType = (TileType) Random.Range(0, numberOfPossibleTypes);
                        CreateCube
                        (
                            cubeType, 
                            cubeFaces[(int)cubeType], 
                            new Vector3(x, y, z) * sizeMultiplier,
                            transform
                        );
                    }
                }
            }
        }

        /// <summary>
        /// Wrapper function to avoid code repetition. Creates and sets up a cube.
        /// </summary>
        /// <param name="cubeType"></param>
        /// <param name="cubeFace"></param>
        /// <param name="position"></param>
        /// <param name="parent"></param>
        void CreateCube(TileType cubeType, Texture2D cubeFace, Vector3 position, Transform parent)
        {
            Debug.Log($"Creating cube of type {cubeType} at position {position}");
            Cube newCube = cubePrefab.CloneObject(position, parent: parent);
            if (newCube == null) throw new Exception("Could not clone cube prefab.");
            newCube.SetTileType(cubeType);
            newCube.SetCubeIcon(cubeFace);
        }
    }
}
