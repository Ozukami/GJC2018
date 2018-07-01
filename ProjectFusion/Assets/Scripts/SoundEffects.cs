using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour {
    private AudioSource audio;

    public AudioClip[] audios;
    // Use this for initialization
    void Start () {

        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySound(int clip)
    {

        audio.clip = audios[clip];
        audio.Play();
    }
}
