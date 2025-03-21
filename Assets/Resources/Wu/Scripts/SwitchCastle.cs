using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchCastle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mHero;
    public string nextScene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.gameObject.GetComponent<CameraMove>().maxLevel*40f-20f
            <mHero.transform.localPosition.x)
        {
            GameManage.sGameManage.changeScene(nextScene,1);
            GameManage.sGameManage.reloadScene();
        }
    }
}
