using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectbutton : MonoBehaviour
{
    // Start is called before the first frame update

    public int buttonNum;
    public TogameAni togame;
    public GameObject intro1;
    public GameObject intro2;
    public GameObject introex;
    public HelpBehavior hBehavior;
    public float timeallow;
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.white;
        GetComponent<Renderer>().material.color *= 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("ButtonNum: " + buttonNum);
        if(buttonNum==4){
            hBehavior.moveIn();
        }
        else {
            MenuManage.sMenuManage.GotoGame(buttonNum);
            togame.Activate();
        }
    }

    private void OnMouseOver()
    {
        if(Time.time>=MenuManage.sMenuManage.selecttimeallow){    if(buttonNum==1) intro1.gameObject.SetActive(true);
            if(buttonNum==2) intro2.gameObject.SetActive(true);
            if(buttonNum==3) introex.gameObject.SetActive(true);
            }
    }

    private void OnMouseExit()
    {
        if(buttonNum==1) intro1.gameObject.SetActive(false);
        if(buttonNum==2) intro2.gameObject.SetActive(false);
        if(buttonNum==3) introex.gameObject.SetActive(false);
        
    }
}
