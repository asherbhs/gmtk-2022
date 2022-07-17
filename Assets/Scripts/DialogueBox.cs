using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    // linked in editor
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameComponent;
    public string[] lines;
    public float textSpeed;
    public GameManager gameManager;

    private int index;

    public void SetCharacterName(string characterName)
    {
        nameComponent.text = characterName;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        textComponent.text = string.Empty;
        gameObject.SetActive(true);
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameManager.OnDialogueDone();
        }
    }

    public void ClearText()
    {
        textComponent.text = "";
        nameComponent.text = "";
    }
}
