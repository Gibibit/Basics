using System.Collections.Generic;

using UnityEngine;

namespace Basics.Numerics
{
    [CreateAssetMenu(menuName = "Basics/Generic/Modifier Collection Data")]
    public class ModifierCollectionData : ScriptableObject
    {
        [SerializeField] private List<string> _keys;
        [SerializeField] private List<float> _values;

        public string someField;
    }
}
