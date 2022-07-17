using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Loader : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)){
            if (SceneManager.GetActiveScene().name != "OutcomeScene")
            {
                LoadOutcome();
            }
            else
            {
                LoadDialogue();
            }
        }
    }

    public void LoadOutcome()
    {
        SceneManager.LoadScene("OutcomeScene");
    }
    public void LoadDialogue()
    {
        SceneManager.LoadScene("DialogueScene");
    }
}
