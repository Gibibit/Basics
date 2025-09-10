using System;
using System.Linq;

using UnityEngine;

namespace Basics
{
    [CreateAssetMenu(menuName = "Basics/Generic/Labeled SpritesObject")]
    public class LabeledSpritesObject : ScriptableObject
    {
        public LabeledSprite[] sprites;

        public Sprite GetSprite(string label)
        {
            return sprites.First(x => x.Label == label).Sprite;
        }

        [Serializable]
        public struct LabeledSprite
        {
            public string Label;
            public Sprite Sprite;
        }
    }
}
