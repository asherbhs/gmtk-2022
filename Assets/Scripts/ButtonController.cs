using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameManager gameManager; // linked in editor

    public void Option0OnClick() { gameManager.PickDialogueOption(0); }
    public void Option1OnClick() { gameManager.PickDialogueOption(1); }
    public void Option2OnClick() { gameManager.PickDialogueOption(2); }
    public void Option3OnClick() { gameManager.PickDialogueOption(3); }
}
