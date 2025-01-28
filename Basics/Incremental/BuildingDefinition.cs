namespace Basics.Incremental
{
    public struct BuildingDefinition
    {
        public string Name;
        public Resource[] Production;

        public BuildingDefinition(string name, params Resource[] production)
        {
            Name=name.ToLowerInvariant();
            Production=production;
        }
    }
}