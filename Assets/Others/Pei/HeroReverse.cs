using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroReverse : MonoBehaviour
{
    // Start is called before the first frame update
    public bool levelChange=false;

    private Vector3[] PositionRecord = {};


    public float recordTime = 5f; // 记录多少秒的回溯数据
    private List<Vector3> stateHistory = new List<Vector3>();
    private bool isRewinding = false;
    private Rigidbody2D rb;





    // void Start()
    // {
        
    // }
    // Update is called once per frame
    // void Update()
    // {
    //     if (levelChange)
    //     {
    //         levelChange = false;
    //         transform.localPosition = new Vector3(-transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
    //         EndandStart();
    //     }
    //     if (Input.GetKeyDown(KeyCode.LeftShift))
    //     {
    //         GameManage.sGameManage.reloadScene();
    //     }
    // }

    // private void EndandStart()
    // {
    //     delete
    // }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopRewind();
        }
    }

    void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    void Record()
    {
        if (stateHistory.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            stateHistory.RemoveAt(0);
        }
        stateHistory.Add(transform.position);
    }

    void Rewind()
    {
        if (stateHistory.Count > 0)
        {
            Vector3 lastState = stateHistory[stateHistory.Count - 1];
            transform.position = lastState;
            stateHistory.RemoveAt(stateHistory.Count - 1);
        }
        else
        {
            StopRewind();
        }
    }

    void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
}
