using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class MusicManager : MonoBehaviour
{
    // Variables
    [Header("Audio Variables")]
    public bool isMusicAutoPlaying = false;
    [Header("Audio Source Variables")]
    public AudioSource audioSource;
    public bool isAudioSourcePlaying = false;
    public bool isMute = false;
    public bool isPlayOnAwake = false;
    public bool isLooping = false;
    [Header("Music List")]
    public List<AudioClip> musicList;
    public bool isListLooping = false;
    public bool isListRandomized = false;
    public int musicListCount;
    public int trackSelected;
    public string trackName;
    public float trackLength;
    public float audioSourcePlaytime;

    // Start is called before the first frame update
    void Start()
    {
        // Getting Audio Source Component on the start
        audioSource = GetComponent<AudioSource>();
        AssignVariablesToComponentAudioSource();

        InitializeAudioSourceValues();

        //PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        isAudioSourcePlaying = audioSource.isPlaying;
        AssignVariablesToComponentAudioSource();

        // Update Audio Source playtime in the global variable exposed to the inspector
        audioSourcePlaytime = audioSource.time;
        // Check if the track is still playing or it finished
        if (audioSourcePlaytime >= trackLength)
        {
            // Stops video player
            StopAudioSource();

            // Checks if the track selected is not yet the last video in the list
            if (trackSelected < musicList.Count - 1)
            {
                LoadNextTrack();
                PlayMusic();
            }
            // If the track selected is equal to the last track in the list,
            // the track selected is set again to the first track in the list
            else if (trackSelected >= musicList.Count - 1)
            {
                ReloadList();
                // Playing music based on isListLooping bool
                if (isListLooping)
                {
                    PlayMusic();
                }
            }
        }

        // Playing music based on isMusicAutoPlaying bool
        /*if (isMusicAutoPlaying)
        {
            PlayMusic();
        }*/
    }

    // Functions
    public void AssignVariablesToComponentAudioSource()
    {
        audioSource.mute = isMute;
        audioSource.playOnAwake = isPlayOnAwake;
        audioSource.loop = isLooping;
    }

    public void InitializeAudioSourceValues()
    {
        // Randomize list function call
        if (isListRandomized)
        {
            RandomizeList();
        }

        trackSelected = musicList.IndexOf(musicList.First());
        musicListCount = musicList.Count - 1;

        //
        audioSource.clip = musicList.ElementAt(trackSelected);

        // Inspector info loading
        trackName = audioSource.clip.name;
        trackLength = audioSource.clip.length;
    }

    public void LoadNextTrack()
    {
        trackSelected++;
        audioSource.clip = musicList.ElementAt(trackSelected);
        trackName = audioSource.clip.name;
        trackLength = audioSource.clip.length;
    }

    public void ReloadList()
    {
        trackSelected = musicList.IndexOf(musicList.First());
        audioSource.clip = musicList.ElementAt(trackSelected);
        trackName = audioSource.clip.name;
        trackLength = audioSource.clip.length;
    }

    public void PlayMusic()
    {
        if (audioSource.clip != null)
        {
            audioSource.Play();
            Debug.Log("Audio Source Clip is playing!");
        }
        else
        {
            Debug.Log("Audio Source Clip is null!");
        }
    }

    public void PauseAudioSource()
    {
        if (audioSource.clip != null)
        {
            audioSource.Pause();
            Debug.Log("Audio Source Clip is paused!");
        }
        else
        {
            Debug.Log("Audio Source Clip is null!");
        }
    }

    public void StopAudioSource()
    {
        if (audioSource.clip != null)
        {
            audioSource.Stop();
            Debug.Log("Audio Source Clip is stopped!");
        }
        else
        {
            Debug.Log("Audio Source Clip is null!");
        }
    }

    public void RandomizeList()
    {
        int n = musicList.Count;
        System.Random rng = new System.Random();

        // Fisher-Yates shuffle algorithm
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            AudioClip value = musicList[k];
            musicList[k] = musicList[n];
            musicList[n] = value;
        }
    }
}
