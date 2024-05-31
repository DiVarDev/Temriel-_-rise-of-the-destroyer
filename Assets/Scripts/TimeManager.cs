using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    //Variables
    [Header("Time Types")]
    public int elapsedSeconds;
    public int elapsedMinutes;
    public int totalSeconds;
    public int totalMinutes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
    public void CaculateTimer(float timeElapsed, float maxTime)
    {
        // Calculate the elapsed time in seconds
        CalculateElapsedSeconds(timeElapsed);

        // Calculate the elapsed time in minutes
        CalculateElapsedMinutes(timeElapsed);

        // Calculate the total song duration in seconds
        CalulateTotalSeconds(maxTime);

        // Calculate minutes from total minutes
        CalulateTotalMinutes(maxTime);
    }

    private void CalculateElapsedSeconds(float timeElapsed)
    {
        // Calculate the elapsed time in seconds
        elapsedSeconds = Mathf.RoundToInt(timeElapsed % 60);
    }

    private void CalculateElapsedMinutes(float timeElapsed)
    {
        
        elapsedMinutes = Mathf.FloorToInt(timeElapsed / 60);
    }

    private void CalulateTotalSeconds(float maxTime)
    {
        // Calculate the total song duration in seconds
        totalSeconds = Mathf.RoundToInt(maxTime % 60);
    }
    
    private void CalulateTotalMinutes(float maxTime)
    {
        // Calculate minutes from total minutes
        totalMinutes = Mathf.FloorToInt(maxTime) / 60;
    }

    public string ReturnStringTimeElapsed()
    {
        // Update the string text with the progress (e.g., "3:48")
        string time = $"{elapsedMinutes}:{elapsedSeconds:D2}/{totalMinutes}:{totalSeconds:D2}";
        return time;
    }
}
