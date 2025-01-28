namespace Basics.Incremental
{
    public struct Resource
    {
        public readonly string Name;
        public float Amount;

        public Resource(string name, float amount)
        {
            Name=name.ToLowerInvariant();
            Amount=amount;
        }

        public override string ToString()
        {
            return $"{Name}: {Amount}";
        }
    }
}