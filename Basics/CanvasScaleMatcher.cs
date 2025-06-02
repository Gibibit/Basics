using UnityEngine;
using UnityEngine.UI;

namespace Basics
{
    /// <summary>
    /// Sets the width/height setting of a canvas scaler based on whether the current aspect ratio is above or below the reference resolution.
    /// </summary>
    [RequireComponent(typeof(CanvasScaler)), ExecuteInEditMode]
    public class CanvasScaleSwitcher : MonoBehaviour
    {
        private CanvasScaler _scaler;

        void Start()
        {
            _scaler = GetComponent<CanvasScaler>();
        }

        void Update()
        {
            float desiredAspect = _scaler.referenceResolution.x/_scaler.referenceResolution.y;
            float aspect = Screen.width/Screen.height;

            if(aspect > desiredAspect)
            {
                _scaler.matchWidthOrHeight = 1f;
            }
            else
            {
                _scaler.matchWidthOrHeight = 0f;
            }
        }
    }
}
