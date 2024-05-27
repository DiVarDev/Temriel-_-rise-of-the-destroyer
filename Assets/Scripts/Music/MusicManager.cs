using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Variables
    [Header("Manager Variables")]
    public bool playMusic = true;
    public bool isAudioSourceMuted;
    public bool isListRandomized = false;

    [Header("Music List ")]
    public List<AudioClip> musicList;
    public int musicListCount;
    public int currentTrackSelectedNumber;
    public string currentTrackName;
    public float trackLength;

    [Header("Music Audio Source")]
    public AudioSource musicAudioSource;
    public float musicAudioSourcePlaytime;

    // Start is called before the first frame update
    void Start()
    {
        // Randomize list function call
        if (isListRandomized)
        {
            RandomizeList();
        }

        currentTrackSelectedNumber = musicList.IndexOf(musicList.First());
        musicListCount = musicList.Count - 1;

        // Audio Source Component
        musicAudioSource = GetComponent<AudioSource>();
        musicAudioSource.clip = musicList.ElementAt(currentTrackSelectedNumber);

        // Inspector info loading
        currentTrackName = musicAudioSource.clip.name;
        trackLength = musicAudioSource.clip.length;

        // Playing music based on playMusic bool
        if (playMusic)
        {
            PlayMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update Audio Source playtime in the global variable exposed to the inspector
        musicAudioSourcePlaytime = musicAudioSource.time;
        // Check if the track is still playing or it finished
        if (musicAudioSourcePlaytime >= trackLength)
        {
            StopMusic();
            NextTrack();
            if (playMusic)
            {
                PlayMusic();
            }
        }
    }

    // Functions
    public void NextTrack()
    {
        if (currentTrackSelectedNumber < musicList.Count - 1)
        {
            currentTrackSelectedNumber++;
        }
        else if (currentTrackSelectedNumber >= musicList.Count - 1)
        {
            currentTrackSelectedNumber = musicList.IndexOf(musicList.First());
        }
        musicAudioSource.clip = musicList.ElementAt(currentTrackSelectedNumber);
        currentTrackName = musicAudioSource.clip.name;
        trackLength = musicAudioSource.clip.length;
    }

    public void PlayMusic()
    {
        if (musicAudioSource.clip != null)
        {
            musicAudioSource.Play();
            Debug.Log("Audio Source Clip is playing!");
        }
        else
        {
            Debug.Log("Audio Source Clip is null!");
        }
    }

    public void PauseMusic()
    {
        if (musicAudioSource.clip != null)
        {
            musicAudioSource.Pause();
            Debug.Log("Audio Source Clip is paused!");
        }
        else
        {
            Debug.Log("Audio Source Clip is null!");
        }
    }

    public void StopMusic()
    {
        if (musicAudioSource.clip != null)
        {
            musicAudioSource.Stop();
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
