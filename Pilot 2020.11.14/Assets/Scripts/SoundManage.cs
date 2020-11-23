using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManage : MonoBehaviour
{
    private AudioSource audioPlayer;
    public AudioClip death;

    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    public void DeathSound()
    {
        audioPlayer.clip = death;
        audioPlayer.Play(0);
    }
}
