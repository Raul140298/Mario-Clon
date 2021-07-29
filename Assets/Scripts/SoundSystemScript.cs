using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystemScript : MonoBehaviour
{
    public static AudioClip jumpSound;
    public static AudioClip overworldSoundtrack;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        //SOUNDS
        jumpSound = Resources.Load<AudioClip>("Sound_jump");

        //SOUNDTRACKS
        overworldSoundtrack = Resources.Load<AudioClip>("Soundtrack_overworld");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
	{
        switch (clip)
		{
            case "Sound_jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
        }
	}

    public static void PlaySoundtrack(string clip2)
    {
        audioSrc.loop = true;
        audioSrc.Stop();
        switch (clip2)
        {
            case "Soundtrack_overworld":              
                audioSrc.clip = overworldSoundtrack;   
                break;
        }
        audioSrc.Play();
    }

    public static void Stop()
    {
        audioSrc.Stop();
    }
}
