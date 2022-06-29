using System.Linq;
using Tiles;
using UnityEngine;

namespace General
{
    /// <summary>
    /// Class responsible for rotating an object around a pivot point with a mouse drag.
    /// </summary>
    public class DragRotator : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] bool buildCentroidOnStart = false;
        [SerializeField] bool rotateXAxis;
        [SerializeField] bool rotateYAxis;
        [SerializeField] bool rotateZAxis;
        
        [Header("Drag")]
        [SerializeField] bool dragEnabled = true;
        [SerializeField] float dragSpeed = 1f;
        [SerializeField] float dragSensitivity = 1f;
        
        /// <summary>
        /// Cached transform of this component.
        /// </summary>
        Transform myTransform;

        /// <summary>
        /// Transform of the centroid of all the objects being dragged.
        /// </summary>
        Transform centroidTransform;
        
        /// <summary>
        /// Auxiliary variable to help with rotation.
        /// </summary>
        Vector3 positionLastFrame;

        // Awake is called before Start
        void Awake() => myTransform = transform;
        
        // Start is called before the first frame update
        void Start()
        {
            if (buildCentroidOnStart) centroidTransform = CalculateCentroid();
            TileBuilder.OnAllTilesBuilt += OnTilesBuilt;
        }
        
        // OnDestroy is called when the script is destroyed
        void OnDestroy() => TileBuilder.OnAllTilesBuilt -= OnTilesBuilt;

        // Update is called once per frame
        void Update()
        {
            if (!dragEnabled || !Input.GetMouseButton(0)) return;
            if (!centroidTransform) return;

            Vector3 mouseDelta = Input.mousePosition - positionLastFrame;
            Vector3 axis = Quaternion.AngleAxis(-90f, Vector3.forward) * mouseDelta;
            float angle = axis.magnitude * dragSpeed * Time.deltaTime;
            axis.x *= rotateXAxis ? dragSensitivity : 0f;
            axis.y *= rotateYAxis ? dragSensitivity : 0f;
            axis.z *= rotateZAxis ? dragSensitivity : 0f;
            myTransform!.RotateAround(centroidTransform.position, axis, angle);
        }
        
        // LateUpdate is called after Update each frame
        void LateUpdate() => positionLastFrame = Input.mousePosition;
        
        /// <summary>
        /// Callback for when the game starts.
        /// </summary>
        void OnTilesBuilt() => centroidTransform = CalculateCentroid();
        
        /// <summary>
        /// Returns the centroid of all the transform's children.
        /// </summary>
        /// <returns></returns>
        Transform CalculateCentroid()
        {
            Transform[] allChildren = transform.gameObject.GetComponentsInChildren<Transform>();
            Vector3 centroidPoint = Vector3.zero;
            int numChildren = allChildren!.Length;
            centroidPoint = allChildren.Aggregate(centroidPoint, (current, child) => current + child!.transform.position);
            centroidPoint /= numChildren;
            GameObject centroidPointObject = new ("Centroid Point") { transform = { position = centroidPoint }};
            return centroidPointObject.transform;
        }
    }
}