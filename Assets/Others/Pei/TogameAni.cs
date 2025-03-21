using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogameAni : MonoBehaviour
{
    // Start is called before the first frame update
    public float anitime=0;
    void Start()
    {
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate(){
        gameObject.SetActive(true);
    }
}
