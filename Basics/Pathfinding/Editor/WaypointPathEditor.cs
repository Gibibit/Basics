using UnityEditor;

using UnityEngine;

namespace Basics.Pathfinding.Editor
{
    [CustomEditor(typeof(WaypointPath))]
    public class WaypointPathEditor : UnityEditor.Editor
    {
        public Texture addWaypointIcon;
        public Texture deleteWaypointIcon;

        private static float _arrangeCircleRadius = 10f;
        private static bool _deletionMode;

        public override void OnInspectorGUI()
        {
            var path = (WaypointPath)target;
            if(GUILayout.Button("Remove all waypoints"))
            {
                path._waypoints.Clear();
            }

            if(GUILayout.Button("Add waypoint"))
            {
                path._waypoints.Add(Vector3.one);
            }

            if(GUILayout.Button("Reset Y position"))
            {
                Undo.RecordObject(path, "Reset waypoint Y positions");
                for(int i = 0; i < path._waypoints.Count; i++)
                {
                    var waypoint = path._waypoints[i];
                    waypoint.y = 0f;
                    path._waypoints[i] = waypoint;
                }
            }

            EditorGUILayout.BeginHorizontal();
            bool circleArrangementButton = GUILayout.Button("Arange in circle");
            GUILayout.Label("Radius:");
            _arrangeCircleRadius = EditorGUILayout.FloatField(_arrangeCircleRadius);
            EditorGUILayout.EndHorizontal();
            if(circleArrangementButton)
            {

                Undo.RecordObject(path, $"Arrange waypoints in circle (radius {_arrangeCircleRadius})");
                for(int i = 0; i < path._waypoints.Count; i++)
                {
                    float t = i*Mathf.PI*2f/path._waypoints.Count;

                    var waypoint = path._waypoints[i];
                    waypoint.x = Mathf.Sin(t)*_arrangeCircleRadius;
                    waypoint.z = -Mathf.Cos(t)*_arrangeCircleRadius;
                    path._waypoints[i] = waypoint;
                }
            }

            if(GUILayout.Button("Toggle deletion mode"))
            {
                _deletionMode = !_deletionMode;
                SceneView.RepaintAll();
            }

            DrawDefaultInspector();
        }

        private void OnSceneGUI()
        {
            var path = (WaypointPath)target;

            EditorGUI.BeginChangeCheck();

            Vector3[] waypointPositions = new Vector3[path._waypoints.Count];
            Vector2Int? waypointToAdd = null;

            for(int i = 0; i < path._waypoints.Count; i++)
            {
                const float BUTTON_HANDLE_SIZE = 0.8f;
                Vector3 waypoint = path._waypoints[i];

                //
                // MOVE WAYPOINT HANDLE
                //
                if(!_deletionMode)
                {
                    waypointPositions[i] = Handles.PositionHandle(path.transform.position + waypoint, Quaternion.identity) - path.transform.position;
                }

                if(i > 0 || path.circular)
                {
                    int previousIndex = MathHelper.Mod(i - 1, path._waypoints.Count);
                    Vector3 previousWaypoint = path._waypoints[previousIndex];
                    Vector3 avg = (waypoint + previousWaypoint)*0.5f;
                    Vector3 position = path.transform.position + avg;
                    Handles.color = Color.yellow;

                    //
                    // ADD WAYPOINT AT SEGMENT BUTTON
                    //
                    if(!_deletionMode)
                    {
                        if(Handles.Button(position, Quaternion.identity, BUTTON_HANDLE_SIZE, HandleUtility.GetHandleSize(position)*BUTTON_HANDLE_SIZE*0.5f, Handles.SphereHandleCap))
                        {
                            waypointToAdd = new Vector2Int(previousIndex, i);
                        }
                        if(addWaypointIcon)
                        {
                            Handles.Label(position, addWaypointIcon);
                        }
                    }
                }

                //
                // DELETE WAYPOINT BUTTON
                //
                if(_deletionMode)
                {
                    Handles.color = Color.red;
                    Vector3 position = path.transform.position + waypoint;
                    float handleSize = HandleUtility.GetHandleSize(position)*BUTTON_HANDLE_SIZE*0.5f;

                    if(Handles.Button(position, Quaternion.identity, BUTTON_HANDLE_SIZE, handleSize, Handles.SphereHandleCap))
                    {
                        waypointToAdd = new Vector2Int(i, 0);
                    }

                    if(deleteWaypointIcon)
                    {
                        Handles.Label(position, deleteWaypointIcon);
                    }
                }
            }

            if(EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(target);
                Undo.RecordObject(path, "Changed waypoint position");
                for(int i = 0; i < waypointPositions.Length; i++)
                {
                    path._waypoints[i] = waypointPositions[i];
                }
            }

            if(waypointToAdd.HasValue)
            {
                EditorUtility.SetDirty(target);
                if(_deletionMode)
                {
                    Undo.RecordObject(path, "Removed waypoint");
                    path._waypoints.RemoveAt(waypointToAdd.Value.x);
                }
                else
                {
                    Undo.RecordObject(path, "Added waypoint");
                    int index = waypointToAdd.Value.y;
                    Vector3 pos = (path.GetWaypointLocal(waypointToAdd.Value.x) + path.GetWaypointLocal(waypointToAdd.Value.y))*0.5f;
                    path._waypoints.Insert(index, pos);
                }
            }
        }
    }
}
