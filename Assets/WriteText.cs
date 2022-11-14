using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using UnityEngine.Events;
using UnityEngine;
using TMPro;

public class WriteText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public MixedRealityKeyboard keyboard;
    public static string keyboardText = "";
    public NoteManager noteManager;
    private void Awake()
    {
        text.text = "Tap to write";
    }
    public void EditText()
    {
        keyboard.ShowKeyboard("", true);
        noteManager.currentNote = this;
    }
    public void CommitText()
    {
        text.text = keyboard.Text.ToString();
    }
}
