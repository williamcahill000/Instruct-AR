using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNode
{
    float max = float.MaxValue;
    public float gScore, hScore;
    public GraphNode previousNode;
    public NavGraphNode physicalRepresentation;
    public Vector3 position;
    //Constructor
    public GraphNode() { Reset(); }
    public GraphNode(float g, float h, GraphNode prev, Vector3 pos) { gScore = g; hScore = h; previousNode = prev; position = pos; }
    public GraphNode(GraphNode source) { gScore = source.gScore; hScore = source.hScore; previousNode = source.previousNode; position = source.position; }
    public void Reset() { gScore = max; hScore = max; previousNode = null; position = Vector3.zero; }
    public static bool operator <(GraphNode a, GraphNode b) { return (a.gScore + a.hScore) < (b.gScore + b.hScore); }
    public static bool operator >(GraphNode a, GraphNode b) { return (a.gScore + a.hScore) > (b.gScore + b.hScore); }
}
