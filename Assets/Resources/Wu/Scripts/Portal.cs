using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{
    static private float lastTime=0;
    static private float outdis=1f;
    public int portalType;
    public GameObject oppoPortal;
    private UnityEngine.Vector3 []AddPosition={new UnityEngine.Vector3(outdis,0,0),new UnityEngine.Vector3(0,outdis,0),new UnityEngine.Vector3(-outdis,0,0),new UnityEngine.Vector3(0,-outdis,0)};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!oppoPortal.activeSelf) return;
        if(collision.name=="Hero"||collision.name=="Box")
        {
            float currentTime=Time.time;
            if(currentTime-lastTime<0.2f) return;
            lastTime=currentTime;
            int oppoPortalType=oppoPortal.GetComponent<Portal>().portalType;
            GameObject obj=collision.GameObject();
            UnityEngine.Vector3 targetPos=oppoPortal.transform.localPosition+AddPosition[oppoPortalType];
            if(collision.name=="Hero") targetPos-=new UnityEngine.Vector3(0,0.9f,0);
            
            UnityEngine.Vector3 V=obj.GetComponent<Rigidbody2D>().velocity;
            int angle=(oppoPortalType-portalType+6)%4;
            for(int i=1;i<=angle;i++)
            {
                (V.x, V.y)=(-V.y, V.x);
            }
            if(V.y>30.0f) V.y=30.0f;
            if(V.y<-17.0f) V.y=-17.0f;
            if(collision.name=="Hero"&&oppoPortal.GetComponent<Portal>().portalType==1) targetPos+=new UnityEngine.Vector3(0,0.3f,0);
            Debug.Log(targetPos);
            Debug.Log(V);
            obj.transform.localPosition=targetPos;
            obj.GetComponent<Rigidbody2D>().velocity=V;
        }
    }
}
