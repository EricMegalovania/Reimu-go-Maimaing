using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHealth : MonoBehaviour
{
    public GameObject talk;
    public BossActManage bBoss;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Talk()
    {
        talk.SetActive(true);
        Destroy(transform.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 sp=transform.localScale;
        Vector3 p=transform.localPosition;
        sp.x=(float)bBoss.health/70.0f*40.0f;
        p.x=(float)(bBoss.health-70.0f)/70.0f*20.0f;
        transform.localScale=sp;
        transform.localPosition=p;
        if(bBoss.health<=0) 
        {
            Invoke("Talk",3.0f);
        }
    }
}
