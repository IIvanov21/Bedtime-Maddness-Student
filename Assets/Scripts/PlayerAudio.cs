using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private AudioClip babyLaugh;
    [SerializeField,Range(0.0f,1.0f)] private float volume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        /* Ignoring effects in code example
        //Ignore Listenere effects in code
        playerAudioSource.bypassListenerEffects = true;//For all listener effects
        playerAudioSource.ignoreListenerPause = true; //For pause
        playerAudioSource.ignoreListenerVolume = true;//For volume

        //Ignore Effects
        playerAudioSource.bypassEffects = true;

        //Ignore Reverb Zone
        playerAudioSource.bypassReverbZones = true;
        */
    }

    // Update is called once per frame
    void Update()
    {
        //If we press the E key and the audio source is not playing
        //play the baby laugh once
        if (Input.GetKeyDown(KeyCode.E) && !playerAudioSource.isPlaying)
        {
            playerAudioSource.PlayOneShot(babyLaugh, volume);
        }

        /*Example Audio Source control calls
         * playerAudioSource.Play();
        playerAudioSource.Pause();
        playerAudioSource.Stop();
        playerAudioSource.PlayDelayed(2.0f);*/

    }
}
