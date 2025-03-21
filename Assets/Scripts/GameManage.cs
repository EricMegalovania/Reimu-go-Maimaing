using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    // Start is called before the first frame update
    public string currentScene;
    public int currentLevel=1;
    static public GameManage sGameManage=new GameManage();
    void Awake()
    {
        sGameManage.currentScene=currentScene;
    }
    public void changeScene(string sceneName,int level)
    {
        if(sceneName!="none") currentScene=sceneName;
        currentLevel=level;
    }
    public void reloadScene()
    {
        SceneManager.LoadScene(currentScene);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
