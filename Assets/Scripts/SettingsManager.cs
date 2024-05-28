using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    // Variables
    [Header("Music Settings")]
    public bool isMusicMuted = false;
    [Range(0f, 1f)]
    public float musicVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
}
