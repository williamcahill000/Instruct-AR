using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PQNode
{
    public NavGraphNode element;
    public float priority;
    public PQNode() { element = null; priority = float.MaxValue; }
    public PQNode(NavGraphNode node, float prio) { element = node; priority = prio; }
}
public class PriorityQueue
{
    private List<PQNode> queue = new();
    private int heapSize = -1;
    public NavGraphNode Top()
    {
        return queue[0].element;
    }
    public int Count() { return queue.Count; }
    public PriorityQueue() {}
    public void Enqueue(NavGraphNode element, float priority)
    {
        PQNode node = new PQNode(element, priority);
        queue.Add(node);
        heapSize++;
        BuildHeapMin(heapSize);
    }
    public bool Contains(NavGraphNode target)
    {
        foreach(PQNode pqnode in queue)
        {
            if (pqnode.element == target)
                return true;
        }
        return false;
    }
    public NavGraphNode Dequeue()
    {
        var returnVal = queue[0].element;
        queue[0] = queue[heapSize];
        queue.RemoveAt(heapSize);
        heapSize--;
        MinHeapify(0);
        return returnVal;
    }
    private void BuildHeapMin(int i)
    {
        while (i >= 0 && queue[(i - 1) / 2].priority > queue[i].priority)
        {
            Swap(i, (i - 1) / 2);
            i = (i - 1) / 2;
        }
    }
    private void MinHeapify(int i)
    {
        int left = i * 2 + 1;
        int right = i * 2 + 2;

        int lowest = i;

        if (left <= heapSize && queue[lowest].priority > queue[left].priority)
            lowest = left;
        if (right <= heapSize && queue[lowest].priority > queue[right].priority)
            lowest = right;

        if (lowest != i)
        {
            Swap(lowest, i);
            MinHeapify(lowest);
        }
    }
    private void Swap(int i, int j)
    {
        var temp = queue[i];
        queue[i] = queue[j];
        queue[j] = temp;
    }
}