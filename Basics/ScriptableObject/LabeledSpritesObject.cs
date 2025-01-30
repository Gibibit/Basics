using System;

using UnityEngine;

namespace Basics
{
    [CreateAssetMenu]
    public class LabeledSpritesObject : ScriptableObject
    {
        public LabeledSprite[] sprites;

        [Serializable]
        public struct LabeledSprite
        {
            public string Label;
            public Sprite Sprite;
        }
    }
}
