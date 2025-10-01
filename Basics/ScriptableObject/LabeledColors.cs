using System;
using System.Linq;

using UnityEngine;

namespace Basics
{
    [CreateAssetMenu(menuName = "Basics/Generic/LabeledColors")]
    public class LabeledColors : ScriptableObject
    {
        public LabeledColor[] colors;

        public Color GetColor(string label)
        {
            return colors.First(x => x.Label == label).Color;
        }

        [Serializable]
        public struct LabeledColor
        {
            public string Label;
            public Color Color;
        }
    }
}
