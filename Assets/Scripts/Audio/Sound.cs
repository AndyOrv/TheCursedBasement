using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
-- Author: Andrew Orvis
-- Description: Sound varaible to be used for audio manager, allows for volume pitch and loop changes
 */


[System.Serializable]
public class Sound
{
    public string name;
    

    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}


