using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideStroyMove : MonoBehaviour
{
    public Camera mainCamera;
    public Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            float speed = 10000f;
            mainCamera.transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
