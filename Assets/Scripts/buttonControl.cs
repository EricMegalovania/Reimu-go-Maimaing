using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int isPush=0;
    public int IsPush
    {
        get { return isPush; }
    }
    public pillarControl pillar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void change(){
        if(isPush>0){
            Color c=GetComponent<Renderer>().material.color;
            c.a=0;
            GetComponent<Renderer>().material.color=c;
        }
        else {
            Color c=GetComponent<Renderer>().material.color;
            c.a=1;
            GetComponent<Renderer>().material.color=c;
        }
        pillar.changeGate();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name=="Hero"||collision.name=="Box")
        {
            if(isPush>0) 
            {
                isPush++;
                return;
            }
            isPush++;
            change();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name=="Hero"||collision.name=="Box")
        {
            isPush--;
            if(isPush==0) change();
        }
    }
}
