using TriInspector;

using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRendererCircle : MonoBehaviour
{
    public int numPoints = 20;
    public float radius = 5f;

    private LineRenderer _line;

    void Start()
    {
        _line = GetComponent<LineRenderer>();
        _line.loop = true;
        GenerateLine();
    }

    private void OnValidate()
    {
        _line = GetComponent<LineRenderer>();
        _line.loop = true;
    }

    [Button]
    public void GenerateLine()
    {
        Vector3[] pos = new Vector3[numPoints];

        for(int i = 0; i < numPoints; i++)
        {
            pos[i] = new Vector3(Mathf.Cos(i/(float)numPoints*Mathf.PI*2f), Mathf.Sin(i/(float)numPoints*Mathf.PI*2f), 0f)*radius;
        }

        _line.positionCount = numPoints;
        _line.SetPositions(pos);
    }
}
