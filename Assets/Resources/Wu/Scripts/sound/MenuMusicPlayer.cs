using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicPlayer : MonoBehaviour
{
    public static int playTime=0;
    private AudioSource audios;
    // Start is called before the first frame update
    private void Awake()
    {
        audios=GetComponent<AudioSource>();
    }
    void Start()
    {
        Debug.Log("cur=" + GameManage.sGameManage.currentLevel+" playTime="+playTime);
        if (GameManage.sGameManage.currentLevel == 1)
        {
            audios.timeSamples = 0;
        //    playTime = 0;
        }
        else
        {
            audios.timeSamples = playTime;
            Debug.Log("enter else, playTime="+ playTime+" sp="+audios.timeSamples);
        }
        audios.Play();
        //audios.PlayDelayed((float)audios.timeSamples/audios.clip.frequency);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("sp=" + audios.timeSamples);
        playTime =audios.timeSamples;
    }
}
