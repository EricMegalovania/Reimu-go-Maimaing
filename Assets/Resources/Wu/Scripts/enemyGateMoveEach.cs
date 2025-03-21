using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGateMoveEach : MonoBehaviour
{
    public GameObject oppoGate;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition=oppoGate.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
