using System.Collections.Generic;

namespace Basics.Incremental
{

    public static class ResourceExtensions
    {
        public static Resource[] Multiply(this Resource[] r, float m)
        {
            Resource[] result = new Resource[r.Length];

            for(int i = 0; i < r.Length; i++)
            {
                result[i] = r[i];
                result[i].Amount *= m;
            }

            return r;
        }
    }
}