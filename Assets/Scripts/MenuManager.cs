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

    public void click()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
