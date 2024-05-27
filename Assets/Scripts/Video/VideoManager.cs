using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    // Variables
    [Header("Video Components")]
    public bool isVideoPlayOnAwake = true;
    public bool isWaitingForFirstFrame = true;
    public bool isPlayingOnLoop = true;
    public bool isSkippingOnDrop = false;
    [Range(0f, 10f)]
    public float playbackSpeed = 1.0f;
    [Header("Video Components")]
    public VideoPlayer videoPlayer;
    [Header("Video List")]
    public List<VideoClip> videoList;
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

        InitializeVideoPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        // Update Video Player playtime in the global variable exposed to the inspector
        videoPlayerPlaytime = Mathf.Round(float.Parse(videoPlayer.time.ToString()));
        // Check if the track is still playing or it finished
        if (videoPlayerPlaytime >= videoLength)
        {
            StopVideo();
            NextVideo();
            if (isVideoPlayOnAwake)
            {
                PlayVideo();
            }
        }
    }

    // Functions
    public void AssignVariablesToComponentVideoPlayer()
    {
        videoPlayer.playOnAwake = isVideoPlayOnAwake;
        videoPlayer.waitForFirstFrame = isWaitingForFirstFrame;
        videoPlayer.isLooping = isPlayingOnLoop;
        videoPlayer.skipOnDrop = isSkippingOnDrop;
        videoPlayer.playbackSpeed = playbackSpeed;
    }

    public void InitializeVideoPlayer()
    {
        // Selecting first video on the list
        videoSelected = videoList.IndexOf(videoList.First());
        videoListCount = videoList.Count - 1;

        // 
        videoPlayer.clip = videoList.ElementAt(videoSelected);

        // Inspector info loading
        videoName = videoPlayer.clip.name;
        videoLength = Mathf.Round(float.Parse(videoPlayer.clip.length.ToString()));

        // Playing video based on playVideo bool
        if (isVideoPlayOnAwake)
        {
            PlayVideo();
        }
    }

    public void NextVideo()
    {
        if (videoSelected < videoList.Count - 1)
        {
            videoSelected++;
        }
        else if (videoSelected >= videoList.Count - 1)
        {
            videoSelected = videoList.IndexOf(videoList.First());
        }
        videoPlayer.clip = videoList.ElementAt(videoSelected);
        videoName = videoPlayer.clip.name;
        videoLength = Mathf.Round(float.Parse(videoPlayer.clip.length.ToString()));
    }

    public void PlayVideo()
    {
        if (videoPlayer.clip != null)
        {
            videoPlayer.Play();
            Debug.Log("Video Player Clip is playing!");
        }
        else
        {
            Debug.Log("Video Player Clip is null!");
        }
    }

    public void PauseVideo()
    {
        if (videoPlayer.clip != null)
        {
            videoPlayer.Pause();
            Debug.Log("Video Player Clip is paused!");
        }
        else
        {
            Debug.Log("Video Player Clip is null!");
        }
    }

    public void StopVideo()
    {
        if (videoPlayer.clip != null)
        {
            videoPlayer.Stop();
            Debug.Log("Video Player Clip is stopped!");
        }
        else
        {
            Debug.Log("Video Player Clip is null!");
        }
    }
}
