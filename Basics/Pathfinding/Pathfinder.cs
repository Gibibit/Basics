using UnityEngine;

namespace Basics.Pathfinding
{
    public class Pathfinder : MonoBehaviour
    {
        [SerializeField] private float _gridResolution = 1f;
        [SerializeField] private Vector3 _area = Vector3.one*10f;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1f, 1f, 1f, 1f);
            Vector3Int gridSize = GetGridSize();
            Vector3 gridSize_f = gridSize;
            Vector3 offset = -gridSize_f*_gridResolution*0.5f + Vector3.one*_gridResolution*0.5f;
            for(int x = 0; x < gridSize.x; x++)
            {
                for(int y = 0; y < gridSize.y; y++)
                {
                    for(int z = 0; z < gridSize.z; z++)
                    {
                        Gizmos.DrawWireCube(transform.position + offset + new Vector3(x, y, z)*_gridResolution, Vector3.one*_gridResolution);
                    }
                }
            }
            //Gizmos.DrawWireCube(transform.position + offset, gridSize_f*_gridResolution);
        }

        private Vector3Int GetGridSize()
        {
            return Vector3Int.CeilToInt(_area/_gridResolution);
        }
    }
}
