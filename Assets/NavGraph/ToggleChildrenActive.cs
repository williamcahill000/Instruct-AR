using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleChildrenActive : MonoBehaviour
{
    public void Toggle()
    {
       foreach(Transform child in transform)
        {
            child.gameObject.SetActive(!child.gameObject.activeSelf);
        }
    }
}
