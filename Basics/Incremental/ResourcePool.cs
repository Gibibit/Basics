using System.Collections.Generic;

namespace Basics.Incremental
{
    public class ResourcePool
    {
        public Dictionary<string, Resource> Resources;

        public ResourcePool()
        {
            Resources = new();
        }

        public void Add(Resource r)
        {
            if(Resources.ContainsKey(r.Name))
            {
                Resource total = r;
                total.Amount += Resources[r.Name].Amount;
                Resources[r.Name] = total;
            }
            else
            {
                Resources.Add(r.Name, r);
            }
        }

        public void Add(params Resource[] r)
        {
            for(int i = 0; i < r.Length; i++)
            {
                Add(r[i]);
            }
        }

        public void Remove(Resource r)
        {
            r.Amount *= -1f;
            Add(r);
        }

        public bool CanAfford(params Resource[] cost)
        {
            for(int i = 0; i < cost.Length; i++)
            {
                if(!Resources.ContainsKey(cost[i].Name) || Resources[cost[i].Name].Amount < cost[i].Amount)
                {
                    return false;
                }
            }

            return true;
        }

        public bool Pay(params Resource[] cost)
        {
            if(!CanAfford(cost)) return false;

            for(int i = 0; i < cost.Length; i++)
            {
                Remove(cost[i]);
            }

            return true;
        }
    }
}