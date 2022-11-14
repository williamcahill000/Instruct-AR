using UnityEngine;

public class DeleteTarget : MonoBehaviour
{
    public void DeleteParent()
    {
        Destroy(transform.parent.gameObject);
    }
}
