using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private DialogueForest currentDialogueForest;
    private int currentDialogueTreeIndex;
    private DialogueTree currentDialogueTree;
    private int rollsRecieved;
    private Button rollButton;
    private Image animalImage;
    private Image weatherImage;
    private Image runeImage;
    private static GameManager managerInstance;

    // all linked in editor
    public Character character;
    public DialogueBox dialogueBox;
    public DialogueButton[] dialogueButtons;
    public GameObject diceShit;
    public Sprite[] diceSprites;
    public OutcomeBox outcomeBox;

    void Start() 
    {
        DontDestroyOnLoad(this);

        if (managerInstance == null)
        {
            managerInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }


        dialogueBox.enabled = true;
        // foreach (DialogueButton b in dialogueButtons) { b.enabled = false; }
        foreach (DialogueButton b in dialogueButtons)
        {
            b.gameObject.SetActive(false);
        }
        diceShit.gameObject.SetActive(false);
        rollButton = diceShit.transform.Find("Roll").gameObject.GetComponent<Button>();
        animalImage = diceShit
            .transform
            .Find("Animal Die/Ani Symbol")
            .gameObject
            .GetComponent<Image>();
        weatherImage = diceShit
            .transform
            .Find("Weather Die/Wea Symbol")
            .gameObject
            .GetComponent<Image>();
        runeImage = diceShit
            .transform
            .Find("Rune Die/Run Symbol")
            .gameObject
            .GetComponent<Image>();

        currentDialogueForest = character.CurrentCharacterData().dialogueForest;
        currentDialogueTreeIndex = 0;
        currentDialogueTree = currentDialogueForest.forest[0]; 
        rollsRecieved = 0;
        ShowCharacterDialogue();
    }

    void ShowCharacterDialogue()
    {
        dialogueBox.SetCharacterName(character.CurrentCharacterData().name);
        dialogueBox.lines = currentDialogueTree.characterDialogue;
        dialogueBox.StartDialogue();
    }

    public void OnDialogueDone()
    {   
        // if outcome scene, change scene
        // if options, wait for roll
        if (currentDialogueTree.dialogueOptions.Length > 0)
        {
            dialogueBox.ClearText();
            dialogueBox.SetCharacterName("You");
            dialogueBox.enabled = false;

            diceShit.gameObject.SetActive(true);
            Color temp = animalImage.color;
            temp.a = 0f;
            animalImage.color = temp;
            temp = weatherImage.color;
            temp.a = 0f;
            weatherImage.color = temp;
            temp = runeImage.color;
            temp.a = 0f;
            runeImage.color = temp;
            animalImage.sprite = DiceTagToSprite(currentDialogueTree.threeDice.animal);
            weatherImage.sprite = DiceTagToSprite(currentDialogueTree.threeDice.weather);
            runeImage.sprite = DiceTagToSprite(currentDialogueTree.threeDice.rune);
            rollButton.enabled = true;
        }
        else 
        {
            outcomeBox.gameObject.SetActive(true);
            outcomeBox.SetText(currentDialogueTree.outcome);
        }

        // else end
    }

    public void OnOutcomeDone()
    {
        outcomeBox.gameObject.SetActive(false);
        // else if more trees, next tree
        if (currentDialogueTreeIndex < currentDialogueForest.forest.Length - 1)
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
    }

    public void OnRollStart() { rollButton.enabled = false; }

    public void OnRollDone()
    {
        rollsRecieved++;
        if (rollsRecieved == 3)
        {
            rollsRecieved = 0;
            ShowButtons();
        }
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
        diceShit.SetActive(false);
        dialogueBox.enabled = true;
        foreach (DialogueButton b in dialogueButtons)
        {
            b.gameObject.SetActive(false);
        }

        currentDialogueTree = currentDialogueTree.dialogueOptions[i].subTree;
        ShowCharacterDialogue();
    }

    Sprite DiceTagToSprite(string tag) { switch (tag)
    {
        case "cat": return diceSprites[0];
        case "wolf": return diceSprites[1];
        case "fish": return diceSprites[2];
        case "rabbit": return diceSprites[3];
        case "bird": return diceSprites[4];
        case "frog": return diceSprites[5];

        case "wind": return diceSprites[6];
        case "lightning": return diceSprites[7];
        case "sun": return diceSprites[8];
        case "snow": return diceSprites[9];
        case "rain": return diceSprites[10];
        case "cloud": return diceSprites[11];

        case "peorth": return diceSprites[12];
        case "aangor": return diceSprites[13];
        case "ehwan": return diceSprites[14];
        case "isa": return diceSprites[15];
        case "akhon": return diceSprites[16];
        case "fo-un": return diceSprites[17];
        default: return null;
    }}

    public void LoadOutcome()
    {
        if (SceneManager.GetActiveScene().name != "OutcomeScene")
        {
            SceneManager.LoadScene("OutcomeScene");
        }
    }

    public void LoadDialogue()
    {
        if (SceneManager.GetActiveScene().name != "DialogueScene")
        {
            SceneManager.LoadScene("DialogueScene");
        }
    }
}
