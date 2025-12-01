using System;
using System.Linq;

using UnityEngine;

namespace Basics
{
    [CreateAssetMenu(menuName = "Basics/Generic/Labeled GameObjects")]
    public class LabeledGameObjects : ScriptableObject
    {
        public LabeledGameObject[] gameObjects;

        public GameObject GetGameObject(string label)
        {
            return gameObjects.First(x => x.Label == label).GameObject;
        }

        public bool TryGetGameObject(string label, out GameObject result)
        {
            if(gameObjects.Any(x => x.Label == label))
            {
                result = GetGameObject(label);
                return true;
            }

            result = null;
            return false;
        }

        [Serializable]
        public struct LabeledGameObject
        {
            public string Label;
            public GameObject GameObject;
        }
    }
}
