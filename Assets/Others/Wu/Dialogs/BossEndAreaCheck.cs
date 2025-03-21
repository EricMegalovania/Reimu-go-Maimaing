using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEndAreaCheck : MonoBehaviour
{
    // Start is called before the first frame update
     public GameObject npc;


    void Start()
    {
        float x = transform.localPosition.x;
        float y = transform.localPosition.y;
        transform.localPosition = new Vector3(x, y, 10);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name=="Hero" || other.name=="HeroLockpick")
        {
            if (npc.GetComponent<BossEndDialogControl>().allowTalk)
        {
            npc.GetComponent<BossEndDialogControl>().canTalk = true;
        }
        }
    }
}
