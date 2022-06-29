using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace General
{
    /// <summary>
    /// Class responsible for rotating an object around a pivot point with a mouse drag.
    /// </summary>
    public class DragRotator : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] bool buildCentroidOnStart;
        [SerializeField] bool rotateXAxis;
        [SerializeField] bool rotateYAxis;
        [SerializeField] bool rotateZAxis;
        
        [Header("Drag")]
        [SerializeField] float dragSpeed = 1f;
        [SerializeField] float autoDragSpeed = 100f;
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
            if (!buildCentroidOnStart) return;
            CalculateCentroid();
        }

        // Update is called once per frame
        void Update()
        {
            if (!Input.GetMouseButton(0)) return;
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
        /// Enables/Disables the drag functionality.
        /// </summary>
        /// <param name="newEnabled"></param>
        public void SetDragEnabled(bool newEnabled) => enabled = newEnabled;
        
        /// <summary>
        /// Returns the centroid of all the transform's children.
        /// </summary>
        /// <returns></returns>
        public void CalculateCentroid()
        {
            Transform[] allChildren = transform.gameObject.GetComponentsInChildren<Transform>();
            Vector3 centroidPoint = Vector3.zero;
            int numChildren = allChildren!.Length;
            centroidPoint = allChildren.Aggregate(centroidPoint, (current, child) => current + child!.transform.position);
            centroidPoint /= numChildren;
            GameObject centroidPointObject = new ("Centroid Point") { transform = { position = centroidPoint }};
            centroidTransform = centroidPointObject.transform;
        }
    
        /// <summary>
        /// Rotates the object around the centroid by the given angle.
        /// </summary>
        /// <param name="angleToRotate"></param>
        public void AutoRotateBy(float angleToRotate)
        {
            if (!enabled) return;
            if (!centroidTransform) throw new Exception("Centroid transform not found.");
            StartCoroutine(RotationCoroutine());

            IEnumerator RotationCoroutine()
            {
                enabled = false;
                float aux = Mathf.Abs(angleToRotate);
                while (aux > 0f)
                {
                    float step = autoDragSpeed * Time.deltaTime;
                    myTransform!.RotateAround(centroidTransform!.position, Vector3.up, step * Mathf.Sign(angleToRotate));
                    aux -= step;
                    yield return null;
                }
                enabled = true;
            }
        }
    }
}