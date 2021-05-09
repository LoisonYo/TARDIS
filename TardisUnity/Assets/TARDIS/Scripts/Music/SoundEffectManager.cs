using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    private AudioSource audioSource;
    private TardisSingleton singleton;
    private TardisState lastState;

    public AudioClip starting;
    public AudioClip humming;
    public AudioClip takeOff;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        singleton = TardisSingleton.GetInstance();
        lastState = TardisState.Flying; //Tout sauf Shutdown
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(audioSource.isPlaying);

        switch (singleton.state)
        {
            case TardisState.Shutdown:
                if (lastState != singleton.state)
                {
                    audioSource.clip = starting;
                    audioSource.Play();
                }
                break;

            case TardisState.TakeOff_1:
                if (lastState != singleton.state)
                {
                    audioSource.clip = takeOff;
                    audioSource.Play();
                }
                break;

            default:
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = humming;
                    audioSource.Play();

                    lastState = singleton.state;
                }
                break;
        }

        lastState = singleton.state;
    }
}
