using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frontSight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.z));
        worldPos.z=-16;
        transform.localPosition=worldPos;
    }
}
