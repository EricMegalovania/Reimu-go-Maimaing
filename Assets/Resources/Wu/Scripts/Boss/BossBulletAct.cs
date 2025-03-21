using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletAct : MonoBehaviour
{
    public float speedY=-18.0f;
    public LayerMask groundlayer;
    private Collider2D colli;
    // Start is called before the first frame update
    void Start()
    {
        colli=GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition+=new Vector3(0,1,0)*speedY*Time.smoothDeltaTime;
        Vector3 p=transform.localPosition;
        if(colli.IsTouchingLayers(groundlayer))
        {
            if(p.y>-5.0f) speedY=15.0f;
        }
        if(p.y>18.0f||p.y<-18.0f) Destroy(transform.gameObject);
    }
}
