using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Cubes;
using General;
using Managers;
using Tiles;
using UnityEngine;
using Tools;
using Unity.VisualScripting;

namespace UI
{
    /// <summary>
    /// UI Class responsible for showing the matched cubes.
    /// Fow now, it shows the cube stack from <see cref="ClickTileMatcher"/>.
    /// </summary>
    public class TileMatcherUI : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] RectTransform container;
        
        [Header("Cube Holder Settings")]
        [SerializeField] Vector2 rectTransformWidthAndHeight = new (60, 60);
        [SerializeField] int rotationRangeXAxis = 15;
        [SerializeField] int scaleFactor = 15;
        [SerializeField] float cubeHolderYRotationSpeed = 15f;
        
        /// <summary>
        /// Fired whenever the UI needs to be updated.
        /// </summary>
        public static Action<IEnumerable<Tile>> OnUpdateUI { get; private set; }

        /// <summary>
        /// Array of <see cref="RectTransform"/>s representing the cubes in the UI.
        /// </summary>
        [NotNull] RectTransform[] cubeUIContainers = Array.Empty<RectTransform>();

        // Awake is called before Start
        void Awake() => OnUpdateUI = UpdateUI;

        // Start is called before the first frame update
        void Start() => CreateUI();
        
        // OnDestroy is called when the script is destroyed
        void OnDestroy() => OnUpdateUI -= UpdateUI;
        
        /// <summary>
        /// Creates the rect transforms that will hold the cube meshes.
        /// </summary>
        void CreateUI()
        {
            cubeUIContainers = new RectTransform[GameManager.GameRules.NumberOfTilesToMatch];
            for (int i = 0; i < cubeUIContainers.Length; i++)
            {
                RectTransform newCubeUIHolder = new GameObject("CubeUIHolder").AddComponent<RectTransform>();
                if (newCubeUIHolder == null) throw new Exception("Could not create new cube UI holder.");
                newCubeUIHolder.SetParent(container, false);
                newCubeUIHolder.SetAsFirstSibling();
                newCubeUIHolder.sizeDelta = rectTransformWidthAndHeight;
                newCubeUIHolder.Rotate(UnityEngine.Random.Range(-rotationRangeXAxis, rotationRangeXAxis), 0, 0);
                newCubeUIHolder.AddComponent<ThreeDimensionalRotator>()?.SetRotationSpeed(y: cubeHolderYRotationSpeed);
                cubeUIContainers[i] = newCubeUIHolder;
            }
        }

        /// <summary>
        /// Called whenever the UI needs to be updated.
        /// </summary>
        /// <param name="cubeCollection"></param>
        void UpdateUI(IEnumerable<Tile> cubeCollection)
        {
            if (cubeCollection == null) throw new Exception("Cube collection is null!");

            List<Tile> collection = cubeCollection.ToList();
            if (!collection.Any())
            {
                foreach (RectTransform cube in cubeUIContainers)
                {
                    if (!cube) throw new Exception("Cube is null!");
                    cube.transform.DestroyAllChildren();
                }
                return;
            }
            
            int i = 0;
            foreach (Tile tile in collection)
            {
                if (!tile) throw new Exception("Cube reference from collection is null!");
                GameObject newTile = tile.ModelGameObject.CloneObject(parent: cubeUIContainers[i]?.transform);
                newTile.transform.localPosition = Vector3.zero;
                newTile.transform.localScale = Vector3.one * scaleFactor;
                i++;
            }
        }
    }
}