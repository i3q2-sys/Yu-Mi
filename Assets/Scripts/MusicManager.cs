using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MusicManager : MonoBehaviour
{
    public string[] Songs;
    int current_song = 0;
    bool playing = false;
    public GameObject AudioUI;
    public TextMeshProUGUI text;
    AudioManager AM;

    public void Start()
    {
        AM = FindObjectOfType<AudioManager>();
    }
    public void Stop()
    {
        playing = false;
        AudioUI.SetActive(false);
        AM.Stop();
    }

    public void Music() 
    {
        if (!playing)
        {
            playing = true;
            AudioUI.SetActive(true);
            AM.Play(Songs[current_song]);
            text.text = Songs[current_song];

        }
        else 
        {
            playing = false;
            AudioUI.SetActive(false);
            AM.Stop();
        }
    }

    public void IncreaseSong() 
    { 
        current_song++;
        current_song = current_song % Songs.Length;
        AM.Stop();
        AM.Play(Songs[current_song]);
        text.text = Songs[current_song];
    }
    public void DecreaseSong() 
    { 
        current_song--;
        current_song = current_song % Songs.Length;
        AM.Stop();
        AM.Play(Songs[current_song]);
        text.text = Songs[current_song];
    }
}
