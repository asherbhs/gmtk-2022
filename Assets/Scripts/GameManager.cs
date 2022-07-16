using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DialogueTree currentDialogueTree;

    // all linked in editor
    public Character character;
    public DialogueBox dialogueBox;
    public DialogueButton[] dialogueButtons;

    void Awake()
    {
    }

    void Start() 
    {
        currentDialogueTree = character.CurrentCharacterData().dialogueTree;
        ShowCharacterDialogue();
    }

    void ShowCharacterDialogue()
    {
        foreach (DialogueButton b in dialogueButtons)
        {
            b.gameObject.SetActive(false);
        }

        dialogueBox.SetCharacterName(character.CurrentCharacterData().name);
        dialogueBox.lines = currentDialogueTree.characterDialogue;
        dialogueBox.StartDialogue();
    }

    public void ShowButtons()
    {
        for (int i = 0; i < currentDialogueTree.dialogueOptions.Length; i++)
        {
            dialogueButtons[i].gameObject.SetActive(true);
            dialogueButtons[i].textMesh.text =
                currentDialogueTree.dialogueOptions[i].playerResponse;
        }
    }

    public void PickDialogueOption(int i)
    {
        currentDialogueTree = currentDialogueTree.dialogueOptions[i].subTree;
        ShowCharacterDialogue();
    }
}
