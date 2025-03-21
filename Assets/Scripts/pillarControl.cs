using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillarControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim; 
    public Collider2D colli;
    public bool isClose=true;
    void Start()
    {
        anim=GetComponent<Animator>();
        
        closeGate();
    }
    public void openGate()
    {
        colli.enabled=false;
        anim.SetBool("close",false);
        anim.SetBool("open",true);
    }
    public void closeGate()
    {
        colli.enabled=true;
        anim.SetBool("close",true);
        anim.SetBool("open",false);
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void changeGate()
    {
        isClose^=true;
        if(isClose) closeGate();
        else openGate();
    }
}
