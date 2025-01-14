using UnityEngine;

namespace Basics
{
    public class InstantiateOnDestroy : MonoBehaviour
    {
        public GameObject prefabToSpawn;

        private void OnDestroy()
        {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity, null);
        }
    }
}
