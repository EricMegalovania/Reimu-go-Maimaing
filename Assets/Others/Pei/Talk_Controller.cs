using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Talk_Controller : MonoBehaviour
{
    //公共参数
    [Header("NPC姓名")]
    public bool allowTalk;
    [Header("是否循环对话")]
    public bool isLoop;
    [Header("对话文本")]
    public TextAsset[] talkTxt;
    [Header("对话提示")]
    public GameObject talkSign;

    public GameObject Qi;
    public GameObject Zi;
    public GameObject Ling;
    public GameObject Qiu;
    


    private float yOff = 0.0f, yZero;
    private const float yOffScale = 0.1f, yOffSpeed = 0.2f;
    private bool rYOff = true; //is y_off_rising

    private float aOff = 0.6f;
    private const float aZero = 0.9f, aOffScale = 0.1f, aOffSpeed = 0.2f;
    private bool rAOff = true; //is a_off_rising





    public GameObject panel;

    //内部参数
    [HideInInspector] public bool canTalk;
    private int txtOrder; //文本指针
    private GameObject text;
    private int textRow;
    private bool isTalking;

    private GameObject spritnow;
    private GameObject spritlast = null;
    void Start()
    {
        canTalk = false;
        textRow = 0;

        panel.gameObject.SetActive(false);
        Zi.gameObject.SetActive(false);
        Qi.gameObject.SetActive(false);
        Qiu.gameObject.SetActive(false);
        Ling.gameObject.SetActive(false);
        yZero = transform.position.y;
}
    


    void Update()
    {
        if (!isTalking && canTalk && Input.GetKeyDown(KeyCode.E))
        {
            isTalking = true;

            panel.gameObject.SetActive(true);
            textRow = 0;
        }
        ShowSign();
        showText();
        CleanData();
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
        p.z = 2;
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

    private void ShowSign() //生成头顶标识
    {
        if (canTalk)
        {
            this.talkSign.SetActive(true);
        }
        else
        {
            this.talkSign.SetActive(false);
        }
    }

    private void OnMouseDown() //点击NPC显示对话UI 并重置Txt文本读取位置
    {
        
    }



    private void showText() //链接txt文本与UI界面Text 并且逐行读取显示 读取完毕隐藏UI
    {
        Text text = panel.transform.Find("Words").gameObject.GetComponent<Text>();

        string[] str = talkTxt[txtOrder].text.Split('\n');       
        string namenow; 

        if (Input.GetKeyDown(KeyCode.E) && isTalking)
        {
            namenow = str[textRow++];
            text.text = str[textRow++];
            if (spritlast!= null)spritlast.SetActive(false);
            Debug.Log(namenow);
            Debug.Log(string.Equals(namenow, "Ling", StringComparison.OrdinalIgnoreCase));

            if(namenow.Equals("八云紫\r", StringComparison.OrdinalIgnoreCase)){
                spritnow =  Zi;

            }
            else if(namenow.Equals("小铃\r", StringComparison.OrdinalIgnoreCase)){
                spritnow = Ling;
            }
            else if(namenow.Equals("琪露诺\r", StringComparison.OrdinalIgnoreCase)){
                spritnow = Qi;
                
            }
            else if(namenow.Equals("阿求\r", StringComparison.OrdinalIgnoreCase)){
                spritnow = Qiu;
            }
            else{
                spritnow = null;
                
            }
            if(spritnow != null)spritnow.SetActive(true);
            spritlast = spritnow;
            panel.transform.Find("NPCName").gameObject.GetComponent<Text>().text = namenow;
        }

        if (textRow == str.Length)
        {
            panel.gameObject.SetActive(false);

            textRow = 0;
            txtOrder = txtOrder + 1; //第一个文本播完后 加载第二个文本
            if(txtOrder == talkTxt.Length)
            {
                txtOrder = 0; //全部文本播完后 重置文本指针
                if(!isLoop) //如果为不循环播放 则变为不可Talk的NPC
                {
                    allowTalk = false;
                    canTalk = false;
                }
            }
            isTalking = false;
        }
    }

    private void CleanData()    //走出对话区域重置当前文本
    {
        if (!canTalk && isTalking)
        {
            textRow = 0;
            isTalking = false;
            panel.gameObject.SetActive(false);
        }
    }
}

