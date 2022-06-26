using UnityEngine;

namespace General
{
    /// <summary>
    /// Class responsible for handling an object's rotation.
    /// </summary>
    public class ThreeDimensionalRotator : MonoBehaviour
    {
        [SerializeField] float xRotationSpeed;
        [SerializeField] float yRotationSpeed;
        [SerializeField] float zRotationSpeed;
        
        /// <summary>
        /// Cached reference to avoid creating a new rotation vector every frame.
        /// </summary>
        Vector3 rotation;
        
        /// <summary>
        /// Sets the rotation speed of the object.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetRotationSpeed(float x = 0f, float y = 0f, float z = 0f)
        {
            xRotationSpeed = x;
            yRotationSpeed = y;
            zRotationSpeed = z;
        }
        
        // Update is called once per frame
        void Update()
        {
            Vector3 rotationVector = new (xRotationSpeed, yRotationSpeed, zRotationSpeed);
            transform.Rotate(rotationVector * Time.deltaTime);
        }
    }
}