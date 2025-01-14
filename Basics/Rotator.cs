using UnityEngine;

namespace Basics
{
    public class Rotator : MonoBehaviour
    {
        public float speed = 100f;
        public float phase = 0f;

        void Update()
        {
            transform.localEulerAngles = Vector3.forward*(Time.time*speed + phase);
        }
    }
}
