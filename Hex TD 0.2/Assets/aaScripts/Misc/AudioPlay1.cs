using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay1 : MonoBehaviour
{

    private AudioSource Playaudio;

    public static bool startplaying;

    private void Start()
    {
        this.Playaudio = GetComponent<AudioSource>();
    }
    public void PlayAudio()
    {
        startplaying = true;
    }


    // Update is called once per frame
    void Update()
    {
        
        if (startplaying == true)
        {
            
            Playaudio.PlayOneShot(Playaudio.clip);
            startplaying = false;
        }



    }
}
