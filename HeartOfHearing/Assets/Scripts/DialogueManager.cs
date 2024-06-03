using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextAsset dialogueFile;
    public DialogueTree dialogue;
    Hashtable dialogueHash;

    private void Awake()
    {
        dialogueHash = new Hashtable();
        dialogue = JsonUtility.FromJson<DialogueTree>(dialogueFile.text);
        foreach(Dialogue dialogues in dialogue.dialogueLines)
        {
            dialogueHash.Add(dialogues.lineTrigger, dialogues);
        }
    }
    public Dialogue GetNextLine(string lineTrigger)
    {
        Dialogue nextLine = (Dialogue)dialogueHash[lineTrigger];
        return nextLine;
    }
}
