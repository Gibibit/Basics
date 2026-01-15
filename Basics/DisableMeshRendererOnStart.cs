using UnityEngine;

namespace Basics
{
    [RequireComponent(typeof(MeshRenderer))]
    public class DisableMeshRendererOnStart : MonoBehaviour
    {
        void Start()
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}