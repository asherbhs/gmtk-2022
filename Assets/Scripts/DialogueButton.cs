using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class DialogueButton : MonoBehaviour
{
    // all linked in editor
    public GameManager gameManager;
    public TextMeshProUGUI textMesh;
    public int optionIndex;

    public void OnClick() { gameManager.PickDialogueOption(optionIndex); }
}
