using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sideStoryExit : MonoBehaviour
{
    public Vector3 iniCameraPosition;
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            float speed = 10000f;
            mainCamera.transform.position = Vector3.Lerp(transform.position, iniCameraPosition, speed * Time.deltaTime);
        }
    }
}
