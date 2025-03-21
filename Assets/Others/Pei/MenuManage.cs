using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManage : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera mMainCamera;
    public static MenuManage sMenuManage=new MenuManage();

    public HelpBehavior hBehavior;
    public SelectManage sSelectManage;

    public float selecttimeallow;
    private float startTime = 0;
    private int startnum;

    private bool isSelect = true;
    private bool enterselect = false;
    void Awake()
    {
        sMenuManage = this;
        sSelectManage.Activate(false);

    }

    // Update is called once per frame

    void soundReset()
    {
        cloudMusicPlayer.playTime=0;
        castleMusicPlayer.playTime=0;
        ForestMusicPlayer.playTime=0;
        ForestBakaMusicPlayer.playTime=0;
        cloudBossMusicPlayer.playTime=0;
    }
    void Update()
    {
        if(hBehavior.onScreen && Input.GetKeyDown(KeyCode.Q))
        {
            hBehavior.moveOut();
        }
        if(hBehavior.onScreen)
        {
            sSelectManage.Activate(false);
        }
        if(enterselect&&!hBehavior.onScreen&&startTime==0)
        {
            sSelectManage.Activate(true);
        }
        if(startTime!=0 && Time.time>=startTime+2.3f && isSelect){
            isSelect = false;
            if(startnum==1){
                soundReset();
                //第一关
                GameManage.sGameManage.changeScene("pre castle",1);
                GameManage.sGameManage.reloadScene();
                Debug.Log("changeScene");
            }
            if(startnum==2){
                soundReset();
                //第二关
                GameManage.sGameManage.changeScene("castle to sky",1);
                
                GameManage.sGameManage.reloadScene();
                Debug.Log("changeScene");

            }
            if(startnum==3){
                soundReset();
                //隐藏关
                GameManage.sGameManage.changeScene("Lockpick_Tutorial",1);
                
                GameManage.sGameManage.reloadScene();
                Debug.Log("changeScene");

            }
        }
    }
    public void EnterSelect()
    {
        enterselect = true;
        Debug.Log("EnterSelect");
        GameObject smain = GameObject.Find("MainMenu");

        smain.SetActive(false);
        sSelectManage.Activate(true);
        selecttimeallow = Time.time+2f;
    }

    public void GotoGame(int num){
        Debug.Log("GotoGame");
        startTime = Time.time;
        startnum = num;
        sSelectManage.gameObject.SetActive(false);
    }
    
    public void CloseSelect()
    {
        sSelectManage.Activate(false);
    }
}

