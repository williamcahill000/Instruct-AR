using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavGraphNode : MonoBehaviour
{
    public bool isPathNode = false;
    public List<NavGraphNode> adjacentNodes = new();
    public float sightDistance = 2.0f;
    public List<NavGraphNode> FindAdjacentNodes()
    {
        adjacentNodes.Clear();
        Collider[] hitCollider = Physics.OverlapSphere(transform.position, 40);
        RaycastHit hit;
        foreach(Collider col in hitCollider)
            if(col.transform.CompareTag("NavGraphNode"))
                if(Physics.Raycast(transform.position, col.transform.position - transform.position, out hit, sightDistance))
                    if(hit.transform.name == col.name)
                        adjacentNodes.Add(col.GetComponent<NavGraphNode>());
        return adjacentNodes;
    }
    public void UpdateAdjacentNodes()
    {
        List<NavGraphNode> newAdjNodes = new();
        Collider[] hitCollider = Physics.OverlapSphere(transform.position, 40);
        RaycastHit hit;
        foreach (Collider col in hitCollider)
            if (col.transform.CompareTag("NavGraphNode"))
                if (Physics.Raycast(transform.position, col.transform.position - transform.position, out hit, sightDistance))
                    if (hit.transform.name == col.name)
                        newAdjNodes.Add(col.GetComponent<NavGraphNode>());
        //if an old neighbor is no longer a neighbor, tell them
        foreach(NavGraphNode oldNeighbor in adjacentNodes)
            if(newAdjNodes.Contains(oldNeighbor) == false)
                oldNeighbor.RemoveAdjNode(this);
        //if there are newNeighbors, tell them
        foreach(NavGraphNode newNeighbor in newAdjNodes)
            if(adjacentNodes.Contains(newNeighbor) == false)
                newNeighbor.AddAdjNode(this);
        adjacentNodes = newAdjNodes;
    }
    public void AddAdjNode(NavGraphNode neighbor)
    {
        this.adjacentNodes.Add(neighbor);
    }
    public void RemoveAdjNode(NavGraphNode neighbor)
    {
        this.adjacentNodes.Remove(neighbor);
    }
}
