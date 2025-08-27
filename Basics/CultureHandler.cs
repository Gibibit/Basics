using System.Globalization;
using System.Threading;

using UnityEngine;

namespace Basics
{
    public class CultureHandler : MonoBehaviour
    {
        [SerializeField] private string _cultureInfo = "invariant";
        private static bool _cultureSet;

        void Awake()
        {
            if(_cultureSet) return;

            CultureInfo cultureInfo;
            switch(_cultureInfo)
            {

                case "invariant":
                case null:
                case "":
                    cultureInfo = CultureInfo.InvariantCulture;
                    break;
                default:
                    cultureInfo = CultureInfo.CreateSpecificCulture(_cultureInfo);
                    break;
            }


            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            Debug.Log($"Set culture to {cultureInfo.EnglishName}");
            _cultureSet = true;
        }

#if UNITY_EDITOR
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void CheckCulture()
        {
            var ch = FindFirstObjectByType<CultureHandler>();
            if(!ch)
            {
                Debug.LogWarning("No CultureHandler used. Locale will be determined by user system settings.");
            }
        }
#endif
    }
}
