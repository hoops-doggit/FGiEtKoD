using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound_MusicHandler : MonoBehaviour {

    public static Sound_MusicHandler sm;

    private int curAudio = 0;

    public AudioClip[] clips;
    private AudioSource source;
    private bool playEndPiece = false;

    private void Awake()
    {
        if (sm == null)
        {
            sm = this;
        }

        else if (sm != this)
        {
            Destroy(gameObject);
        }

        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    public void PlayEndBit () {
        playEndPiece = true;
        source.clip = clips[2];
        source.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (!source.isPlaying && !playEndPiece)
        {
            if (curAudio > 1)
            {
                curAudio = 1;
            }

            source.clip = clips[curAudio];

            source.Play();

            curAudio++;
        }

	}
}
