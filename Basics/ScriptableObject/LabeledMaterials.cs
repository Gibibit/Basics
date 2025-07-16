using System;
using System.Linq;

using UnityEngine;

namespace Basics
{
    [CreateAssetMenu]
    public class LabeledMaterials : ScriptableObject
    {
        public LabeledMaterial[] materials;

        public Material GetMaterial(string label)
        {
            return materials.First(x => x.Label == label).Material;
        }

        [Serializable]
        public struct LabeledMaterial
        {
            public string Label;
            public Material Material;
        }
    }
}
