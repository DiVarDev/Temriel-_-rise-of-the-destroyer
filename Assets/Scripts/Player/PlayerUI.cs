using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    // Variables
    public TMP_Text healthText;
    public TMP_Text promptText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }

    // Functions
    public void UpdateText(TMP_Text text, string message)
    {
        text.text = message;
    }
}
