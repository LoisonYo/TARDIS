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

        if (lastState != singleton.state)
        {
            switch (singleton.state)
            {
                case TardisState.Shutdown:
                    if (lastState != singleton.state)
                    {
                        audioSource.Stop();
                        audioSource.clip = starting;
                        audioSource.Play();
                    }
                    break;

                case TardisState.Starting_1:
                case TardisState.Starting_2:
                case TardisState.Starting_3:
                case TardisState.Starting_4:
                case TardisState.Started:
                    if (!audioSource.isPlaying)
                    {
                        audioSource.Stop();
                        audioSource.clip = humming;
                        audioSource.Play();
                    }
                    break;


                case TardisState.TakeOff_1:
                    audioSource.Stop();
                    audioSource.clip = takeOff;
                    audioSource.Play();
                    break;
            }

            lastState = singleton.state;
        }
    }
}
