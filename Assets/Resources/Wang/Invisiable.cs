using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisiable : MonoBehaviour
{
    public GameObject mHero;
    public Collider2D targetCollider;
    private Coroutine collisionCheckRoutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(mHero.transform.localPosition.y < -15f || mHero.transform.localPosition.x < -21f)
        {
            GameManage.sGameManage.reloadScene();
        }
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // 停止之前的检测（防止重复）
            if (collisionCheckRoutine != null)
                StopCoroutine(collisionCheckRoutine);
            
            // 启动新的延时检测
            collisionCheckRoutine = StartCoroutine(DelayedCollisionCheck(other));
        }
    }

    IEnumerator DelayedCollisionCheck(Collider2D other)
    {
        yield return new WaitForSeconds(0.05f);

        // 延迟后再次验证碰撞状态
        if (other != null && 
            other.IsTouching(targetCollider))
        {
            Debug.Log("延时确认卡墙");
            GameManage.sGameManage.reloadScene();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 离开时立即取消检测
        if (other.CompareTag("Obstacle") && collisionCheckRoutine != null)
        {
            StopCoroutine(collisionCheckRoutine);
            collisionCheckRoutine = null;
        }
    }
}
