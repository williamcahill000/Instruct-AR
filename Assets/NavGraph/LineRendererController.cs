using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points;
    public NavGraph graph;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        if(graph == null)
            graph = GameObject.Find("NavGraph").GetComponent<NavGraph>();
    }
    public void SetupLine(Transform[] points)
    {
        lr.positionCount = points.Length;
        this.points = points;
    }
    private void Update()
    {
        for(int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
    }
}
