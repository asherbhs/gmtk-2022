using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonController : MonoBehaviour
{
    public GameObject manager;
    public GameObject buttonParent;
    public void debug()
    {
        Debug.Log("Based");
    }

    public void NavigateBook(string text)
    {
        buttonParent.SetActive(false);
        buttonParent.transform.parent.Find("ToFillTextBox").GetComponent<TextMeshProUGUI>().text = text;
    }

    public void NavigateBookBack()
    {
        buttonParent.transform.parent.Find("ToFillTextBox").GetComponent<TextMeshProUGUI>().text = "";
        buttonParent.SetActive(true);
    }
}
