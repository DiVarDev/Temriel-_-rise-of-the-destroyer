using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables
    private SceneLoader sceneLoader;
    [Header("Scenes indexes")]
    public int goodEnding = 2;
    public int badEnding = 3;
    public GameObject boss;
    [Header("Timer")]
    public TimeManager timeManager;
    public TMP_Text timerText;
    public float time;
    public float maxTime = 120;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();

        timeManager = GetComponent<TimeManager>();

        time = maxTime;

        UpdateTimerText(time, maxTime);

        StartCoroutine(CountdownTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (!boss.activeInHierarchy)
        {
            LoadGoodEnding();
        }

        if (time <= 0.0f)
        {
            LoadBadEnding();
        }
    }

    // Corountines
    IEnumerator CountdownTimer()
    {
        while (time >= 0.0f)
        {
            UpdateTimerText(time, maxTime);
            yield return new WaitForSeconds(1.0f);
            time--;
        }
    }

    // Functions
    public void UpdateTimerText(float time, float maxTime)
    {
        timeManager.CaculateTimer(time, maxTime);
        timerText.text = timeManager.ReturnStringTimeElapsed();
    }

    public void LoadGoodEnding()
    {
        sceneLoader.LoadSceneAsyncSingleByIndex(goodEnding);
    }

    public void LoadBadEnding()
    {
        sceneLoader.LoadSceneAsyncSingleByIndex(badEnding);
    }
}
