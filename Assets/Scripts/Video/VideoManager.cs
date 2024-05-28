using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    // Variables
    [Header("Video Variables")]
    public bool isVideoAutoPlaying = false;
    [Header("Video Player Variables")]
    public VideoPlayer videoPlayer;
    public bool isVideoPlayerPlaying = false;
    public bool isPlayOnAwake = false;
    public bool isWaitingForFirstFrame = true;
    public bool isPlayingLooping = false;
    public bool isSkippingOnDrop = true;
    [Range(0f, 10f)]
    public float playbackSpeed = 1.0f;
    [Header("Video List")]
    public List<VideoClip> videoList;
    public bool isListLooping = false;
    public int videoListCount;
    public int videoSelected;
    public string videoName;
    public float videoLength;
    public float videoPlayerPlaytime;


    // Start is called before the first frame update
    void Start()
    {
        // Getting Video Player Component on the start
        videoPlayer = GetComponent<VideoPlayer>();
        AssignVariablesToComponentVideoPlayer();

        InitializeVideoPlayerValues();

        //PlayVideo();
    }

    // Update is called once per frame
    void Update()
    {
        isVideoPlayerPlaying = videoPlayer.isPlaying;
        AssignVariablesToComponentVideoPlayer();

        // Update Video Player playtime in the global variable exposed to the inspector
        videoPlayerPlaytime = Mathf.Ceil(float.Parse(videoPlayer.time.ToString()));
        // Checks if the video is still playing or it has finished
        if (videoPlayerPlaytime >= videoLength)
        {
            // Stops video player
            StopVideoPlayer();

            // Checks if the video selected is not yet the last video in the list
            if (videoSelected < videoList.Count - 1)
            {
                LoadNextVideo();
                PlayVideo();
            }
            // If the video selected is equal to the last video in the list,
            // the video selected is set again to the first video in the list
            else if (videoSelected >= videoList.Count - 1)
            {
                ReloadList();
                // Playing video based on isListLooping bool
                if (isListLooping)
                {
                    PlayVideo();
                }
            }
        }

        // Playing video based on isVideoAutoPlaying bool
        /*if (isVideoAutoPlaying)
        {
            PlayVideo();
        }*/
    }

    // Functions
    public void AssignVariablesToComponentVideoPlayer()
    {
        videoPlayer.playOnAwake = isPlayOnAwake;
        videoPlayer.waitForFirstFrame = isWaitingForFirstFrame;
        videoPlayer.isLooping = isPlayingLooping;
        videoPlayer.skipOnDrop = isSkippingOnDrop;
        videoPlayer.playbackSpeed = playbackSpeed;
    }

    public void InitializeVideoPlayerValues()
    {
        // Selecting first video on the list
        videoSelected = videoList.IndexOf(videoList.First());
        videoListCount = videoList.Count - 1;

        // 
        videoPlayer.clip = videoList.ElementAt(videoSelected);

        // Inspector info loading
        videoName = videoPlayer.clip.name;
        videoLength = Mathf.Ceil(float.Parse(videoPlayer.clip.length.ToString()));
    }

    public void LoadNextVideo()
    {
        Debug.Log("Loading next video...");
        videoSelected++;
        videoPlayer.clip = videoList.ElementAt(videoSelected);
        videoName = videoPlayer.clip.name;
        videoLength = Mathf.Ceil(float.Parse(videoPlayer.clip.length.ToString()));
    }

    public void ReloadList()
    {
        Debug.Log("Reloading video list...");
        videoSelected = videoList.IndexOf(videoList.First());
        videoPlayer.clip = videoList.ElementAt(videoSelected);
        videoName = videoPlayer.clip.name;
        videoLength = Mathf.Ceil(float.Parse(videoPlayer.clip.length.ToString()));
    }

    public void PlayVideo()
    {
        if (videoPlayer.clip != null)
        {
            videoPlayer.Play();
            Debug.Log("Video Player Clip is playing...");
        }
        else
        {
            Debug.Log("Video Player Clip is null!");
        }
    }

    public void PauseVideoPlayer()
    {
        if (videoPlayer.clip != null)
        {
            videoPlayer.Pause();
            Debug.Log("Video Player Clip is paused...");
        }
        else
        {
            Debug.Log("Video Player Clip is null!");
        }
    }

    public void StopVideoPlayer()
    {
        if (videoPlayer.clip != null)
        {
            videoPlayer.Stop();
            Debug.Log("Video Player Clip is stopped...");
        }
        else
        {
            Debug.Log("Video Player Clip is null!");
        }
    }
}
