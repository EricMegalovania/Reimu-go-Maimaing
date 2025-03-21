using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSelect : MonoBehaviour
{

// 播放动画

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Enter()
    {
        gameObject.SetActive(true);
    }


}
