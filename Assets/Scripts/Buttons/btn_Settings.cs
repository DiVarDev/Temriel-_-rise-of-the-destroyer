using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btn_Settings : MonoBehaviour
{
    public Button btn_settings;

    // Start is called before the first frame update
    void Start()
    {
        Button but = btn_settings.GetComponent<Button>();
        but.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Settings");
    }
}