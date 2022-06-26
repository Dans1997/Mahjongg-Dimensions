using System.Collections;
using Tools;
using UnityEngine;

namespace Cubes
{
    /// <summary>
    /// Class which handles cube destruction.
    /// </summary>
    public class CubeDestructionHandler : MonoBehaviour
    {
        // Start is called before the first frame update
        IEnumerator Start()
        {
            yield return StartCoroutine(transform.LerpLocalScaleTo(Vector3.zero, 0.5f));
            Destroy(gameObject);
        }
    }
}