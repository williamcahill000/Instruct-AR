using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NavGraph))]
public class NavGraphEditor : Editor
{
    /*
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        NavGraph myScript = (NavGraph)target;

        if(GUILayout.Button("")) 
        {
            myScript.PopulateNodes();
        }
        if (GUILayout.Button("Populate Graph"))
        {
            myScript.AddNodes();
            myScript.AddEdges();
        }


        if (GUILayout.Button("Print NavGraph"))
        {
            Debug.Log("Nodes: " + myScript.GetNodeCount());
            Debug.Log("Edges: " + myScript.GetEdgeCount());
            myScript.DrawGraph();
        }
        if (GUILayout.Button("Build Path"))
        {
            Debug.Log("Build Path");
            myScript.BuildPath();
        }
        if (GUILayout.Button("Draw Path"))
        {
            myScript.DrawPath();
        }
    }
    */
}
