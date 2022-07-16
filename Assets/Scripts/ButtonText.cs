using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonText : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string text;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
