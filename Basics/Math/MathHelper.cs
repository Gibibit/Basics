using UnityEngine;

namespace Basics
{
    public static class MathHelper
    {
        public static int Mod(int x, int m)
        {
            return (x%m + m)%m;
        }
        public static float Mod(float x, float m)
        {
            return (x%m + m)%m;
        }

        public static Vector3 ToVector3(this Vector2Int v) => new Vector3(v.x, v.y, 0f);
    }
}
