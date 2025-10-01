namespace Basics
{
    public static class MathHelper
    {
        public static int Mod(int x, int m)
        {
            return (x%m + m)%m;
        }
    }
}
