using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaManager : MonoBehaviour
{
    // Variables
    [Header("Video Component")]
    public VideoManager videoManager;
    private bool isVideoPlayerPlaying = false;
    [Header("Music Component")]
    public MusicManager musicManager;
    private bool isAudioSourcePlaying = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isVideoPlayerPlaying = videoManager.isVideoPlayerPlaying;
        isAudioSourcePlaying = musicManager.isAudioSourcePlaying;

        CheckingSyncForMedia();
    }

    // Functions
    public void CheckingSyncForMedia()
    {
        if (!isVideoPlayerPlaying && !isAudioSourcePlaying)
        {
            Debug.Log("Playing Video and Music!");
            videoManager.PlayVideo();
            musicManager.PlayMusic();
        }
    }
}
