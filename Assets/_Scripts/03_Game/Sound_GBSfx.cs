using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Sound_GBSfx : MonoBehaviour {

    public static Sound_GBSfx gbsfx;


    public AudioClip[] jumpSFXClips;
    public AudioClip moveLeft;
    public AudioClip moveRight;

    private AudioSource source;
    private bool playEndPiece = false;

    private void Awake()
    {
        if (gbsfx == null)
        {
            gbsfx = this;
        }

        else if (gbsfx != this)
        {
            Destroy(gameObject);
        }

        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    public void JumpSFX()
    {
        source.clip = jumpSFXClips[Random.Range(0,jumpSFXClips.Length)];
        source.Play();
    }

    public void MoveLeft()
    {
        source.clip = moveLeft;
        source.Play();
    }
    public void MoveRight()
    {
        source.clip = moveRight;
        source.Play();
    }

}
