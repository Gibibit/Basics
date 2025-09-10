using UnityEngine;
using UnityEngine.Serialization;

namespace Basics
{
    [CreateAssetMenu(menuName = "Basics/Generic/Texts Object")]
    public class TextsObject : ScriptableObject
    {
        [FormerlySerializedAs("text")]
        public string[] texts;
    }
}