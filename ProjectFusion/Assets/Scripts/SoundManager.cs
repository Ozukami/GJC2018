using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    private AudioSource[] audioSources;

    public static SoundManager soundMan = null;

    void Awake()
    {
        if (soundMan == null)
        {
            soundMan = this;
        }
        else if (soundMan != this)
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        audioSources = GetComponents<AudioSource>();
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySound(int clip)
    {
//        audio.clip = audios[clip];
//        audio.Play();
          audioSources[clip].Play();
    }
}
