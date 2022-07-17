using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonController : MonoBehaviour
{   

    public GameManager manager;
    public GameObject buttonParent;
    public GameObject book;
    public GameObject bookButton;
 

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

    public void CloseBook()
    {
        book.SetActive(false);
        bookButton.SetActive(true);
    }

    public void OpenBook()
    {
        book.SetActive(true);
        bookButton.SetActive(false);
    }

}
