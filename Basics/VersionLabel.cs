using TMPro;

using UnityEngine;

namespace Basics
{
    [RequireComponent(typeof(TMP_Text))]
    public class VersionLabel : MonoBehaviour
    {
        public string versionPrefix = "version";

        void Start()
        {
            var tmp = GetComponent<TMP_Text>();
            string version = Application.version;
            if(!string.IsNullOrWhiteSpace(versionPrefix)) version = versionPrefix + " " + version;
            tmp.text = version;
        }
    }
}
