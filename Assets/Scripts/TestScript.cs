using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    void ExampleDialogueLoading()
    {
        DialogueTree dt = JsonUtility.FromJson<DialogueTree>
        (
            Resources.Load("Dialogue/test-dialogue-tree").ToString()
        );
        Debug.Log(dt.characterDialogue);
        Debug.Log(dt.dialogueOptions[0].playerResponse);
        Debug.Log(dt.dialogueOptions[0].karma);
        Debug.Log(dt.dialogueOptions[0].subTree.characterDialogue);
        Debug.Log(dt.dialogueOptions[0].subTree.dialogueOptions.Length);
    }
}
