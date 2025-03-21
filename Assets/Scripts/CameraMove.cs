using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxLevel;
    private int gameLevel;
    public int cameraLevel;
    public GameObject mHero;
    public UnityEngine.Vector3 []mHeroPosition;
    void Awake()
    {
        cameraLevel=gameLevel=GameManage.sGameManage.currentLevel;
        mHero.transform.localPosition=mHeroPosition[gameLevel-1];
        move();
    }
    private void changeGameLevel()
    {
        GameManage.sGameManage.changeScene("none",gameLevel);
    }
    private void move()
    {
        Vector3 p=transform.localPosition;
        p.x=cameraLevel*40f-40f;
        p.y=0;
        transform.localPosition=p;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            GameManage.sGameManage.reloadScene();
        }
        else if(Input.GetKeyDown(KeyCode.O))
        {
            if(gameLevel>1)
            {
                gameLevel--;
                changeGameLevel();
                GameManage.sGameManage.reloadScene();
            }
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            if(gameLevel<maxLevel)
            {
                gameLevel++;
                changeGameLevel();
                GameManage.sGameManage.reloadScene();
            }
        }
        else if(mHero.transform.localPosition.x>gameLevel*40f-20f)
        {
            if(gameLevel<maxLevel)
            {
                gameLevel++;
                changeGameLevel();
            }
        }
        int cnt=(int)((mHero.transform.localPosition.x+20f)/40)+1;
        if(cameraLevel!=cnt&&cnt<=maxLevel)
        {
            cameraLevel=cnt;
            move();
        }
    }
}
