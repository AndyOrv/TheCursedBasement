using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
-- Author: Andrew Orvis
-- Description: Simple class to be attached to objects allowing them to either play audio at start or trigger audio when collided with
 */

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] string whatAudio;

    [SerializeField] bool onStart = false;

    private void Start()
    {
        if (onStart)
        {
            FindObjectOfType<AudioManager>().Play(whatAudio);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play(whatAudio);
    }
}
