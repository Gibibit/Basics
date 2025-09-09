using System.Collections.Generic;

namespace Basics.Numerics
{
    public class Modifiers<TKey>
    {
        public ModifierCollection<TKey> Additive = new();
        public ModifierCollection<TKey> Multipliers = new();
        public ModifierCollection<TKey> Compounding = new();

        public void ApplyModifiers(Dictionary<TKey, float> values)
        {
            foreach(var kvp in Additive.Values)
            {
                foreach(float additive in kvp.Value)
                {
                    values[kvp.Key] += additive;
                }
            }

            foreach(var kvp in Multipliers.Values)
            {
                float multi = 1f;
                foreach(float multiplier in kvp.Value)
                {
                    multi += multiplier;
                }
                values[kvp.Key] *= multi;
            }

            foreach(var kvp in Compounding.Values)
            {
                foreach(float compounding in kvp.Value)
                {
                    values[kvp.Key] *= compounding;
                }
            }
        }
    }
}