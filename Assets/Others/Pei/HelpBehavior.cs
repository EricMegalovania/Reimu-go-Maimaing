using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpBehavior : MonoBehaviour
{
    public bool helpOut = false;
    public bool helpIn = false;

    public float speed = 2f;
    
    private float startTime = 0f;

    public bool onScreen = false; 
    public float startY = -24;
    public float endY = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(0, startY, -7);
    }

    // Update is called once per frame
    void Update()
    {
        if(helpIn)
        {
            onScreen = true;
            if(transform.localPosition.y == endY)
            {
                helpIn = false;

            }
            float lerpValue = Mathf.Lerp(startY, endY, (Time.time-startTime )* speed);
            transform.localPosition = new Vector3(0, lerpValue, -7);

        }
        if(helpOut)
        {
            onScreen = false;
            if(transform.localPosition.y == startY)
            {
                helpOut = false;
            }
            float lerpValue = Mathf.Lerp(endY, startY, (Time.time-startTime )* speed);
            transform.localPosition = new Vector3(0, lerpValue, -7);

        }

    }

    public void moveIn()
    {
        helpIn = true;
        startTime = Time.time;
    }

    public void moveOut()
    {
        helpOut = true;
        startTime = Time.time;
    }
}
