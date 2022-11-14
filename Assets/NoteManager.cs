using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public GameObject notePrefab, noteStartPos, mainCamera;
    Vector3 temp;
    public WriteText currentNote;
    public void CreateNote()
    {
        GameObject newNote = Instantiate(notePrefab, noteStartPos.transform.position, Quaternion.identity, this.transform);
        newNote.transform.LookAt(mainCamera.transform.position, Vector3.up);
    }
    public void CommitToCurrentNote()
    {
        currentNote.CommitText();
    }
}
