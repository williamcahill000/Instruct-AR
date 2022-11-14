using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class NavGraphNodeCreator : MonoBehaviour
{
    public GameObject nodePrefab, nextNode;
    public NavGraph navGraph;
    public void CreateNewNode()
    {
        nextNode = Instantiate(nodePrefab, transform.position, Quaternion.identity);
        nextNode.GetComponent<NavGraphNode>().UpdateAdjacentNodes();
        //rename it
        nextNode.transform.name = "Node " + navGraph.transform.childCount.ToString();
        //make it a valid node
        nextNode.tag = "NavGraphNode";
        //move it into the correct position
        nextNode.transform.parent = navGraph.transform;
    }
}
