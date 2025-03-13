using UnityEngine;

namespace Basics
{
    public class DisableOnPlatform : MonoBehaviour
    {
        [TriInspector.InfoBox("Disables this object for the platforms ticked below")]
        public bool webgl;
        public bool windows, linux, mac, android, ios;

        private void Start()
        {
#if UNITY_WEBGL
            if(webgl)
            {
                gameObject.SetActive(false);
            }
#endif
#if UNITY_STANDALONE_WINDOWS
            if(windows)
            {
                gameObject.SetActive(false);
            }
#endif
#if UNITY_STANDALONE_LINUX
            if(linux)
            {
                gameObject.SetActive(false);
            }
#endif
#if UNITY_STANDALONE_OSX
            if(mac)
            {
                gameObject.SetActive(false);
            }
#endif
#if UNITY_ANDROID
            if(android)
            {
                gameObject.SetActive(false);
            }
#endif
#if UNITY_IOS
            if(ios)
            {
                gameObject.SetActive(false);
            }
#endif
        }
    }
}
