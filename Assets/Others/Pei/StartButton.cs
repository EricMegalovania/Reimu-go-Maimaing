using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Startbutton : MonoBehaviour
{
    // Start is called before the first frame update
    public ButtonCtrl startred;
    public EnterSelect enterselect;


    void Start()
    {
        GetComponent<Renderer>().material.color = Color.white;
        GetComponent<Renderer>().material.color *= 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter() 
    {
     
        startred.Activate(true);

    }
    private void OnMouseExit() 
    {
        startred.Activate(false);
    }
    void OnMouseDown()
    {
        MenuManage.sMenuManage.EnterSelect();
        enterselect.Enter();
    }

}
