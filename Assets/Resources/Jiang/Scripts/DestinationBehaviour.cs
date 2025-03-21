using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestinationBehaviour : MonoBehaviour
{
    private float yOff = 0.0f, yZero;
    private const float yOffScale = 0.2f, yOffSpeed = 0.2f;
    private bool rYOff = true; //is y_off_rising

    private float aOff = 0.6f;
    private const float aZero = 0.8f, aOffScale = 0.2f, aOffSpeed = 0.2f;
    private bool rAOff = true; //is y_off_rising

    public bool isLast; //only for Lockpick_#NUMBER
    private string prevScene = "", nextScene = "";
    private WinWinWin win = null;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        string cur = gameObject.scene.name;
        //Debug.Log("cur:" + cur);
        if (cur == "Lockpick_Tutorial")
        {
            nextScene = "Lockpick_1";
        }
        else
        {
            string t = cur[(cur.LastIndexOf("_") + 1)..];
            //Debug.Log("cur id=" + t);
            int x = 0;
            foreach (char c in t)
            {
                x *= 10;
                x += (c - '0');
            }
            if (x > 1)
            {
                prevScene = "Lockpick_" + (x - 1);
            }
            else
            {
                prevScene = "Lockpick_Tutorial";
            }
            nextScene = isLast ? "TheEnd" : ("Lockpick_" + (x + 1));
        }
        //Debug.Log(" pre:" + prevScene + " next:" + nextScene);

        win = GameObject.Find("/CanvasWin").GetComponent<WinWinWin>();
        Debug.Assert(win != null);
        yZero = transform.position.y;
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Load(ref prevScene);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            Load(ref nextScene);
        }
        if (rYOff == true)
        {
            yOff += yOffSpeed * Time.smoothDeltaTime;
            if (yOff > yOffScale)
            {
                yOff = yOffScale;
                rYOff = false;
            }
        }
        else
        {
            yOff -= yOffSpeed * Time.smoothDeltaTime;
            if (yOff < -yOffScale)
            {
                yOff = -yOffScale;
                rYOff = true;
            }
        }
        Vector3 p = transform.position;
        p.y = yZero + yOff;
        p.z = 1;
        transform.position = p;
        if (rAOff == true)
        {
            aOff += aOffSpeed * Time.smoothDeltaTime;
            if (aOff > aOffScale)
            {
                aOff = aOffScale;
                rAOff = false;
            }
        }
        else
        {
            aOff -= aOffSpeed * Time.smoothDeltaTime;
            if (aOff < -aOffScale)
            {
                aOff = -aOffScale;
                rAOff = true;
            }
        }
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        color.a = aZero + aOff;
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }
    /// <summary>
    /// Layer: Dest(10)
    /// Collision with only Layer:Hero(3)
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!flag)
        {
            flag = true;
            if (!isLast)
            {
                win.WinEnter();
            }
            else
            {
                LoadNextScene();
            }
        }
    }
    private void Load(ref string scene)
    {
        if (scene.Length > 0)
        {
            GameManage.sGameManage.changeScene(scene, 1);
            GameManage.sGameManage.reloadScene();
        }
    }
    public void LoadNextScene()
    {
        Load(ref nextScene);
    }
}
