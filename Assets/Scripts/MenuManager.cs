using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button PlayButton;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = PlayButton.GetComponent<Button>();
    }

    public void Click()
    {
        Debug.Log("CLICK");
        UnityEngine.SceneManagement.SceneManager.LoadScene("DialogueScene");
    }
}
