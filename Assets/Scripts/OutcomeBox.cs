using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutcomeBox : MonoBehaviour
{
    // linked in editor
    public TextMeshProUGUI textComponent;
    public GameManager gameManager;

    public void SetText(string t)
    {
        textComponent.text = t;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameManager.OnOutcomeDone();
        }
    }
}
