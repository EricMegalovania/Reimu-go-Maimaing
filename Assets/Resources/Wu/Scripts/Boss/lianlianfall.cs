using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lianlianfall : MonoBehaviour
{
    public float speedY=-18.0f;
    public float zAngle=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition+=new Vector3(0,1,0)*speedY*Time.smoothDeltaTime;
        zAngle+=5.0f;
        transform.rotation = Quaternion.Euler(0, 0, zAngle);
        Vector3 p=transform.localPosition;
        if(p.y>18.0f||p.y<-18.0f) Destroy(transform.gameObject);
    }
}
