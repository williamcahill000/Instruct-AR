using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

public class NavGraph : MonoBehaviour
{
    float max = float.MaxValue;
    public List<NavGraphNode> physicalNodes;
    public NavGraphNode start, end;
    public List<NavGraphNode> path;
    public NavGraphNode lastNodeHeld;
    public NavGraphVisualizer visualizer;
    private void Start() 
    { 
        PopulateNodes();
        visualizer = GetComponent<NavGraphVisualizer>();
    }
    public void PopulateNodes()
    {
        //if null, make a new one
        if (physicalNodes == null) physicalNodes = new();
        //If populated, clear it
        if (physicalNodes.Count > 0) physicalNodes.Clear();
        //Add all children
        foreach (Transform t in transform)
        {
            NavGraphNode temp = t.GetComponent<NavGraphNode>();
            physicalNodes.Add(temp);
            temp.FindAdjacentNodes();
        }
    }
    //hScore is cartesian distance, and gScore is path length from start to a node
    public void FindPath()
    {
        PriorityQueue openSet = new();
        openSet.Enqueue(start, 0);
        Dictionary<NavGraphNode, NavGraphNode> cameFrom = new();
        Dictionary<NavGraphNode, float> gScore = new(); //default is infinity
        Dictionary<NavGraphNode, float> fScore = new(); //default is infinity

        gScore[start] = 0; //zero path length from start to start
        fScore[start] = Vector3.Distance(start.transform.position, end.transform.position);

        while(openSet.Count() > 0)
        {
            NavGraphNode currentNode = openSet.Dequeue();
            if (currentNode == end)
            {
                path = ReconstructPath(cameFrom, currentNode);
                return;
            }

            foreach(NavGraphNode adjN in currentNode.adjacentNodes)
            {
                float tentativeGscore = gScore[currentNode] + Vector3.Distance(currentNode.transform.position, adjN.transform.position);
                if (gScore.ContainsKey(adjN) == false || tentativeGscore < gScore[adjN]) //if we haven't expanded adjN, or if we're aproaching from a better path
                {
                    cameFrom[adjN] = currentNode;
                    gScore[adjN] = tentativeGscore;
                    fScore[adjN] = tentativeGscore + Vector3.Distance(adjN.transform.position, end.transform.position);
                    if(openSet.Contains(adjN) == false)
                        openSet.Enqueue(adjN, fScore[adjN]);
                }
            }
        }
        path = new List<NavGraphNode>();
    }
    private List<NavGraphNode> ReconstructPath(Dictionary<NavGraphNode, NavGraphNode> cameFrom, NavGraphNode current)
    {
        foreach (NavGraphNode node in physicalNodes)
            node.isPathNode = false;

        List<NavGraphNode> path = new();
        while(cameFrom.ContainsKey(current)) {
            path.Add(current);
            current = cameFrom[current];
            current.isPathNode = true;
        }
        path.Add(current);
        path.Reverse();
        return path;
    }
    //Utility functions
    public void PrintVector3(Vector3 target) { Debug.Log("x: " + target.x + " y: " + target.y + " z: " + target.z); }
    //Getters
    public int GetNodeCount() { return this.physicalNodes.Count; }
    //Setters
    public void SetLastNodeHeld(NavGraphNode source) { lastNodeHeld = source; }
    public void SetStart() { start = lastNodeHeld; }
    public void SetEnd() { end = lastNodeHeld; }
}
