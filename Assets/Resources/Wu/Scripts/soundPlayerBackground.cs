using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundPlayerBackground : MonoBehaviour
{
    static int playTime;
    private AudioSource audios;
    // Start is called before the first frame update
    void Start()
    {
        audios=GetComponent<AudioSource>();
        audios.timeSamples=playTime;
        audios.Play();
    }

    // Update is called once per frame
    void Update()
    {
        playTime=audios.timeSamples;
        Debug.Log(playTime);
    }
}
