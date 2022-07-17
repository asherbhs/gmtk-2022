using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DialogueForest currentDialogueForest;
    private int currentDialogueTreeIndex;
    private DialogueTree currentDialogueTree;

    // all linked in editor
    public Character character;
    public DialogueBox dialogueBox;
    public DialogueButton[] dialogueButtons;

    void Start() 
    {
        currentDialogueForest = character.CurrentCharacterData().dialogueForest;
        currentDialogueTreeIndex = 0;
        currentDialogueTree = currentDialogueForest.forest[0]; 
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

    public void OnDialogueDone()
    {
        // if options, show buttons
        if (currentDialogueTree.dialogueOptions.Length > 0) { ShowButtons(); }
        // else if more trees, next tree
        else if (currentDialogueTreeIndex < currentDialogueForest.forest.Length - 1)
        {
            currentDialogueTreeIndex++;
            currentDialogueTree = 
                currentDialogueForest.forest[currentDialogueTreeIndex];
            ShowCharacterDialogue();
        }
        // else if more characters, next character
        else
        {
            character.NextCharacter();
            currentDialogueTreeIndex = 0;
            currentDialogueForest = 
                character.CurrentCharacterData().dialogueForest;
            currentDialogueTree = 
                currentDialogueForest.forest[currentDialogueTreeIndex];
            ShowCharacterDialogue();
        }

        // else end
    }

    public void OnRollDone() {}

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
