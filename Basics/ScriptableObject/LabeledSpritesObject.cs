using GluonGui.Dialog;

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

        public bool TryGetSprite(string label, out Sprite result)
        {
            if(sprites.Any(x => x.Label == label))
            {
                result = sprites.First(x => x.Label == label).Sprite;
                return true;
            }

            result = null;
            return false;
        }

        [Serializable]
        public struct LabeledSprite
        {
            public string Label;
            public Sprite Sprite;
        }
    }
}
