using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    public List<GameObject> scans;
    public void ShowEnvironment(string target)
    {
        foreach (GameObject go in scans)
        {
            if (go.name == target)
                go.SetActive(true);
            else
                go.SetActive(false);
        }
    }
    public void ToggleTargetChild(string name)
    {
        foreach (GameObject go in scans)
        {
            if (go.name == name)
                go.SetActive(!go.activeSelf);
        }
    }
}
