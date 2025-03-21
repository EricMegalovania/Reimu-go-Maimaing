using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestMusicPlayer : MonoBehaviour
{
    public static int playTime=0;
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
    }
}
