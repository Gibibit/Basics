using UnityEngine;

namespace Basics
{
    [CreateAssetMenu(menuName = "Basics/Generic/Text Object")]
    public class TextObject : ScriptableObject
    {
        [Multiline] public string text;
    }
}