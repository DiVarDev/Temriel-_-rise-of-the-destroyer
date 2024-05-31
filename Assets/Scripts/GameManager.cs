using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables
    private SceneLoader sceneLoader;
    [Header("Scenes indexes")]
    public int goodEnding = 2;
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!boss.activeInHierarchy)
        {
            LoadGoodEnding();
        }
    }

    // Functions
    public void LoadGoodEnding()
    {
        sceneLoader.LoadSceneAsyncSingleByIndex(goodEnding);
    }
}
