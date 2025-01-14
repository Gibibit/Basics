using UnityEngine;

namespace Basics
{
    public static class Helpers
    {
        public static int Mod(int x, int m)
        {
            return (x%m + m)%m;
        }
    }
}
