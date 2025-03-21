using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkCheck : MonoBehaviour
{
    public GameObject npc;
    public int numTri=0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (npc.GetComponent<Talk_Controller>().allowTalk)
        {
            numTri++;
            npc.GetComponent<Talk_Controller>().canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(--numTri==0) npc.GetComponent<Talk_Controller>().canTalk = false;
    }
}

