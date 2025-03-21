using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeoutMenu : MonoBehaviour
{
    public GameObject pauseMenu; 
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=1;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale==1&&Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale=0;
            pauseMenu.SetActive(true);
        }
        else if(Time.timeScale==0&&Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale=1;
            pauseMenu.SetActive(false);
        }
    }
}
