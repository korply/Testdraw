using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawnLine : MonoBehaviour
{

    public GameObject linePrefabs;
    public GameObject currentLine;
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider2D;
    public List<Vector2> fingerPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(-tempFingerPos, fingerPosition[fingerPosition.Count - 1]) > 0.1f)
            {
                UpdateLine(tempFingerPos);
            }
        }
    }

    void CreateLine()
    {
        currentLine = Instantiate(linePrefabs, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider2D = currentLine.GetComponent<EdgeCollider2D>();
        fingerPosition.Clear();
        fingerPosition.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPosition.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, fingerPosition[0]);
        lineRenderer.SetPosition(1, fingerPosition[1]);
        edgeCollider2D.points = fingerPosition.ToArray();
    }

    void UpdateLine(Vector2 newFingerPos)
    {
        fingerPosition.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        edgeCollider2D.points = fingerPosition.ToArray();

    }
}
