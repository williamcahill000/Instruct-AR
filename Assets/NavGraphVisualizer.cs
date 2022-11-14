using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavGraphVisualizer : MonoBehaviour
{
    public NavGraph navGraph;
    public GameObject edgePrefab, edgeParent;
    public LineRenderer pathLine;
    private void Start()
    {
        if (navGraph == null)
            navGraph = GetComponent<NavGraph>();
    }
    public void DrawGraph()
    {
        Debug.Log("Drawing Graph - in spirit.");
        //Setup edges along path
        pathLine.positionCount = navGraph.path.Count;
        for(int i = 0; i < pathLine.positionCount; i++)
            pathLine.SetPosition(i, navGraph.path[i].transform.position);
    }
}
