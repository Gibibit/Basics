using System.Collections.Generic;

namespace Basics.Numerics
{
    public class ModifierCollection<TKey>
    {
        public Dictionary<TKey, List<float>> Values = new();

        public void Add(TKey key, float value)
        {
            if(!Values.ContainsKey(key))
            {
                Values.Add(key, new List<float>());
            }

            Values[key].Add(value);
        }

        public void Reset(TKey key)
        {
            if(!Values.ContainsKey(key))
            {
                Values.Add(key, new List<float>());
            }

            Values[key].Clear();
        }

        public void ResetAll()
        {
            foreach(var kvp in Values)
            {
                kvp.Value.Clear();
            }
        }
    }
}