using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btn_Play : MonoBehaviour
{
    public Button btn_play;

    // Start is called before the first frame update
    void Start()
    {
        Button but = btn_play.GetComponent<Button>();
        but.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void TaskOnClick()
    {
        SceneManager.LoadScene("Level1");
    }
}