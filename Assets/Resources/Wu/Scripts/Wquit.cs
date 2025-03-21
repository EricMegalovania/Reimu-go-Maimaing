using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wquit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        GameManage.sGameManage.changeScene("Menu",1);
        GameManage.sGameManage.reloadScene();
        Time.timeScale=1;
    }
}
