using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class PortalBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D ground;
    public bool YorB;
    public bool isStatic=false;
    private float speed=15.0f;
    public BoxCollider2D []detectGround={null,null,null,null,null,null,null,null};
    private float detectDistance=2.2f;
    public Vector3 direct;
    private UnityEngine.Vector3 []detectDirection={
        new Vector3(1,0,0),new Vector3(1,1,0),
        new Vector3(0,1,0),new Vector3(-1,1,0),
        new Vector3(-1,0,0),new Vector3(-1,-1,0),
        new Vector3(0,-1,0),new Vector3(1,-1,0)
    };
    private UnityEngine.Vector2 []detectSize={
        new Vector2(0.1f,0.7f),new Vector2(0.1f,0.1f),
        new Vector2(0.7f,0.1f),new Vector2(0.1f,0.1f),
        new Vector2(0.1f,0.7f),new Vector2(0.1f,0.1f),
        new Vector2(0.7f,0.1f),new Vector2(0.1f,0.1f),
    };
    public GameObject portalGun;
    void Start()
    {
        if(YorB==false) 
        {
            GetComponent<Renderer>().material.color=new Color(0.6117647f,0.6039216f,0.8431373f);
        }
        else
        {
            GetComponent<Renderer>().material.color=new Color(0.9803922f,0.7764707f,0.4313726f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isStatic) return;
        transform.localPosition+=direct*speed*Time.smoothDeltaTime;
    }
    private float Toint(float x)
    {
        x+=1000.0f;
        int a=(int)x;
        float c=x-(float)a;
        if(c>0.5f) return x-c+1.0f-1000.0f;
        else return x-c-1000.0f;
    }
    private void whichDirection()
    {
        string output="";
        for(int i=0;i<=7;i++) 
            if(detectGround[i].IsTouching(ground)) output+="1";
            else output+="0";
        Vector3 p=transform.position;
        Debug.Log(p);
        if(output=="00111110"){
            p.x=Toint(p.x);
            portalGun.GetComponent<PortalGun>().setPortal(true,YorB,p,0);
        } else if(output=="10001111"){
            p.y=Toint(p.y);
            portalGun.GetComponent<PortalGun>().setPortal(true,YorB,p,1);
        } else if(output=="11100011"){
            p.x=Toint(p.x);
            portalGun.GetComponent<PortalGun>().setPortal(true,YorB,p,2);
        } else if(output=="11111000"){
            p.y=Toint(p.y);
            portalGun.GetComponent<PortalGun>().setPortal(true,YorB,p,3);
        } 
        Debug.Log(p);
        Destroy(transform.GameObject());
    }
    private void Work()
    {
        if(isStatic) return;
        float Dis_x,Dis_y;
        Dis_x=transform.localPosition.x-(int)transform.localPosition.x;
        Dis_y=transform.localPosition.y-(int)transform.localPosition.y;
        Debug.Log(ground.GameObject().name);
        for(int i=0;i<=7;i++)
        {
            detectGround[i]=transform.GameObject().AddComponent<BoxCollider2D>();
            detectGround[i].offset=detectDirection[i]*detectDistance;
            detectGround[i].isTrigger=true;
            detectGround[i].size=detectSize[i];
            
            isStatic=true;
        }
        Color c=GetComponent<Renderer>().material.color;
        c.a=0;
        GetComponent<Renderer>().material.color=c;
        Invoke("whichDirection",0.1f);
    
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision==ground)
        {
            Work();
            return;
        }
        if(collision.name!="Hero") Destroy(transform.GameObject());
    }
    void OnBecameInvisible()
    {
        portalGun.GetComponent<PortalGun>().setPortal(false,false,Vector3.zero,0);
        Destroy(transform.GameObject());
    }
}
