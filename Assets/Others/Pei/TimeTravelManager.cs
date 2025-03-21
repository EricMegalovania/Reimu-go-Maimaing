using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeTravelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string currentScene;
    public int currentLevel=1;
    static public TimeTravelManager sGameManage=new TimeTravelManager();

    public HeroReverse mHeroReverse;

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
        mHeroReverse.levelChange = true;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
