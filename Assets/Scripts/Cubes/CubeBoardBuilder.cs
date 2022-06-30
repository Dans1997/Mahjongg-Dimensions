using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
    /// It will build a XYZ grid of tiles, and then randomly assign them to a random type.
    /// </summary>
    public class CubeBoardBuilder : TileBuilder
    {
        [SerializeField] Tile tilePrefab;
        
        /// <summary>
        /// In this case, builds a tower following the <see cref="Managers.GameManager.GameRules"/>.
        /// </summary>
        public override void BuildGameBoard() => Build(gridDimensions: GameManager.GameRules.GameBoardDimensions);

        /// <summary>
        /// Builds the game board.
        /// TODO: how to make sure there is always at least one valid play?
        /// </summary>
        /// <param name="iconPath">Resources folder path to load tile faces.</param>
        /// <param name="gridDimensions"></param>
        void Build(string iconPath = null, Vector3 gridDimensions = default)
        {
            Texture2D[] iconTextures = Resources.LoadAll<Texture2D>(string.IsNullOrEmpty(iconPath)
                ? Constants.DefaultIconTexturePath
                : iconPath);
            
            if (iconTextures == null) throw new Exception("Could not load textures from resources.");
            if (!tilePrefab) throw new Exception("Tile prefab is null.");

            int numberOfPossiblePositions = (int) (gridDimensions.x * gridDimensions.y * gridDimensions.z);
            int numberOfPossibleTypes = GameManager.GameRules.NumberOfPossibleTileTypes;
            float sizeMultiplier = tilePrefab.GetWorldSize();
            System.Random rnd = new ();
            iconTextures = iconTextures.OrderBy(_ => rnd.Next()).Take(numberOfPossibleTypes).ToArray();
            Dictionary<Vector3, Tile> tiles = new (numberOfPossiblePositions);
            
            // Create A Stack With All Possible Positions
            List<Vector3> listedPositions = new List<Vector3>(numberOfPossiblePositions);
            for (int x = 0; x < gridDimensions.x; x++)
            for (int y = 0; y < gridDimensions.y; y++)
            for (int z = 0; z < gridDimensions.z; z++)
                listedPositions.Add(new Vector3(x, y, z));
            Stack<Vector3> availablePositions = new Stack<Vector3>(listedPositions.OrderBy(_ => rnd.Next()));
            
            // Cache Transform For Efficiency
            Transform myTransform = transform;
            
            // Always Create Pairs of Tiles
            while (availablePositions.Count >= 2)
            {
                TileType tileType = (TileType) Random.Range(0, numberOfPossibleTypes);
                Vector3 randomPosition1 = availablePositions.Pop() * sizeMultiplier;
                Vector3 randomPosition2 = availablePositions.Pop() * sizeMultiplier;
                CreateAndAddTile(tileType, iconTextures[(int)tileType], randomPosition1, myTransform);
                CreateAndAddTile(tileType, iconTextures[(int)tileType], randomPosition2, myTransform);
            }

            BuiltTiles = tiles;
            InvokeOnAllTilesBuilt();
            
            void CreateAndAddTile(TileType tileType, Texture2D iconTexture, Vector3 position, Transform parent)
            {
                Tile newTile = CreateTile(tileType, iconTexture, position, parent);
                tiles.Add(newTile.transform.position, newTile);
            }
        }

        /// <summary>
        /// Wrapper function to avoid code repetition. Creates and sets up a tile.
        /// </summary>
        /// <param name="tileType"></param>
        /// <param name="iconTexture"></param>
        /// <param name="position"></param>
        /// <param name="parent"></param>
        [return: NotNull]
        Tile CreateTile(TileType tileType, Texture2D iconTexture, Vector3 position, Transform parent)
        {
            Debug.Log($"Creating tile of type {tileType} at position {position}");
            Tile newTile = tilePrefab.CloneObject(position, parent: parent);
            newTile.SetTileType(tileType);
            newTile.SetTileIcon(iconTexture);
            return newTile;
        }
    }
}
