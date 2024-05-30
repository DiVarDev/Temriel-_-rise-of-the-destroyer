using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceManager : MonoBehaviour
{
    // Variables
    public List<GameObject> buttonsUI;
    public List<GameObject> objectsUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
    public void DisableUIButtons()
    {
        foreach (GameObject button in buttonsUI)
        {
            if (button != null)
            {
                button.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void EnableUIButtons()
    {
        foreach (GameObject button in buttonsUI)
        {
            if (button != null)
            {
                button.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void HideUIObjects()
    {
        foreach (GameObject obj in objectsUI)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }

    public void ShowUIObjects()
    {
        foreach (GameObject obj in objectsUI)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
