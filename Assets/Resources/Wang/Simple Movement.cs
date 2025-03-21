using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float distance = 5f;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float xOffset = Mathf.PingPong(Time.time * moveSpeed, distance);

        transform.position = startPos + Vector3.right * (xOffset - distance / 2);
    }
}
