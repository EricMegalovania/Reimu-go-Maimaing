using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkyShiftDialogControl : MonoBehaviour
{
    [Header("NPC姓名")]
    public bool allowTalk;
    public GameObject scene1;
    public GameObject scene2;

    [Header("对话文本")]
    public TextAsset[] talkTxt;

    public GameObject Qi;
    public GameObject Zi;
    public GameObject Ling;
    public GameObject Qiu;
    

    public GameObject panel;

    //内部参数
    [HideInInspector] public bool canTalk;
    private int txtOrder; //文本指针
    private GameObject text;
    private int textRow;
    private bool isTalking;

    private bool firstime;

    private GameObject spritnow;
    private GameObject spritlast = null;
    void Start()
    {
        canTalk = false;
        textRow = 0;
        isTalking = false;
        firstime = true;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -100);
        panel.gameObject.SetActive(false);
        Zi.gameObject.SetActive(false);
        Qi.gameObject.SetActive(false);
        Qiu.gameObject.SetActive(false);
        Ling.gameObject.SetActive(false);
}
    


    void Update()
    {
        
        if (!isTalking && canTalk)
        {
            isTalking = true;

            textRow = 0;
            
            Time.timeScale = 0;

        }
        showText();

    }



    private void showText() //链接txt文本与UI界面Text 并且逐行读取显示 读取完毕隐藏UI
    {
        Text text = panel.transform.Find("Words").gameObject.GetComponent<Text>();

        string[] str = talkTxt[txtOrder].text.Split('\n');       
        string namenow; 
        if(firstime && isTalking)
        {
            firstime = false;
            panel.gameObject.SetActive(true);

            namenow = str[textRow++];
            text.text = str[textRow++];
            if (spritlast!= null)spritlast.SetActive(false);
            Debug.Log(namenow);
            Debug.Log("first");
            Debug.Log(textRow);

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

            return;
        }
        if (isTalking && Input.GetKeyDown(KeyCode.E))
        {
            panel.gameObject.SetActive(true);

            namenow = str[textRow++];
            text.text = str[textRow++];
            if (spritlast!= null)spritlast.SetActive(false);
            Debug.Log(namenow);
                        Debug.Log(textRow);


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
            if(firstime){
                firstime = false;
                return;
            } 
            if(textRow==10) {
                scene1.SetActive(false);
                scene2.SetActive(true);
            }
        }

        if (textRow == str.Length)
        {
            panel.gameObject.SetActive(false);

            textRow = 0;
            txtOrder = txtOrder + 1; //第一个文本播完后 加载第二个文本
            if(txtOrder == talkTxt.Length)
            {
                txtOrder = 0; //全部文本播完后 重置文本指针

                allowTalk = false;
                canTalk = false;
                
            }
            isTalking = false;
            Time.timeScale = 1;
        }
    }

}
