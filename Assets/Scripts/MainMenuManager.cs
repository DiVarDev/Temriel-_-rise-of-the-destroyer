using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenuManager : MonoBehaviour
{
    // Variables
    [Header("User Interface")]
    public bool isCursorHidden = true;
    public int mouseHideCountdown = 10;
    public int time;
    private SceneLoader sceneLoader;
    [Header("Scenes indexes")]
    public int gameScene = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (isCursorHidden)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        gameObject.AddComponent<SceneLoader>();
        sceneLoader = GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Cursor.visible == true)
        {
            StartCoroutine(HideMouseCountdown());
        }*/
    }

    // Coroutines
    private IEnumerator HideMouseCountdown()
    {
        time = mouseHideCountdown;
        while (time > 0)
        {
            yield return new WaitForSeconds(1f);
            time--;
        }
        Cursor.visible = false;
    }

    // Functions
    public void PlayGame()
    {
        sceneLoader.LoadSceneAsyncSingleByIndex(gameScene);
    }

    public void QuitGame()
    {
        // Closing application
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
