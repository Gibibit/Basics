using System.Collections.Generic;

using UnityEngine;

namespace Basics.Pathfinding
{
    public class WaypointPath : MonoBehaviour
    {
        [SerializeField, HideInInspector] internal List<Vector3> _waypoints;
        [SerializeField] internal bool circular;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            for(int i = 0; i < _waypoints.Count; i++)
            {
                Vector3 waypoint = transform.position + _waypoints[i];
                Gizmos.DrawSphere(waypoint, 1f);
                if(i > 0)
                {
                    Vector3 previousWaypoint = transform.position + _waypoints[i - 1];
                    Gizmos.DrawLine(previousWaypoint, waypoint);
                }
            }

            if(circular && _waypoints.Count > 1)
            {
                Vector3 firstWaypoint = transform.position + _waypoints[0];
                Vector3 lastWaypoint = transform.position + _waypoints[_waypoints.Count - 1];
                Gizmos.DrawLine(lastWaypoint, firstWaypoint);
            }
        }

        public Vector3 GetWaypointLocal(int index)
        {
            if(_waypoints.Count == 0) return Vector3.zero;

            index = MathHelper.Mod(index, _waypoints.Count);
            return _waypoints[index];
        }
    }
}
