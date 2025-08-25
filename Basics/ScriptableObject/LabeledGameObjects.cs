using System;
using System.Linq;

using UnityEngine;

namespace Basics
{
    [CreateAssetMenu]
    public class LabeledGameObjects : ScriptableObject
    {
        public LabeledGameObject[] gameObjects;

        public GameObject GetGameObject(string label)
        {
            return gameObjects.First(x => x.Label == label).GameObject;
        }

        [Serializable]
        public struct LabeledGameObject
        {
            public string Label;
            public GameObject GameObject;
        }
    }
}
