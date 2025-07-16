using UnityEngine;

namespace Basics
{
    public class ToggleActiveOnKeyPress : MonoBehaviour
    {
        public KeyCode key;
        public GameObject target;

#if UNITY_EDITOR
        private void Awake()
        {
            if(target == gameObject)
            {
                Debug.LogError("ToggleActiveOnKeyPress does not work when assigned to its own gameobject", this);
            }
        }
#endif

        void Update()
        {
            if(Input.GetKeyDown(key))
            {
                target.SetActive(!target.activeSelf);
            }
        }
    }
}
