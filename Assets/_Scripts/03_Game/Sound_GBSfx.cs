using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Sound_GBSfx : MonoBehaviour {

    public static Sound_GBSfx instance;


    public AudioClip[] jumpSFXClips;
    public AudioClip moveLeft;
    public AudioClip moveRight;
    public AudioSource[] audioSources;

    private AudioSource source;
    private bool playEndPiece = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        source = GetComponent<AudioSource>();
    }

    private AudioSource PickAudioSource()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (!audioSources[i].isPlaying)
            {
                return audioSources[i];
            }
        }

        return null;
    } 

    // Use this for initialization
    public void JumpSFX()
    {
        AudioSource source = PickAudioSource();
        source.clip = jumpSFXClips[Random.Range(0,jumpSFXClips.Length)];
        source.Play();
    }

    public void MoveLeft()
    {
        AudioSource source = PickAudioSource();
        source.clip = moveLeft;
        source.Play();
    }
    public void MoveRight()
    {
        AudioSource source = PickAudioSource();
        source.clip = moveRight;
        source.Play();
    }

}
