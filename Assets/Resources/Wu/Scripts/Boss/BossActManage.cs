using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class BossActManage : MonoBehaviour
{
    public GameObject gate1;
    public GameObject gate2;
    public int health=70;
    private SpriteRenderer sr;
    public float timegap;
    private float lasttime;
    private Animator anim;
    public GameObject mHero;
    [SerializeField] private Material hitMat; // 受击时的材质
    private Material originalMat; // 原始的材质


    //执行闪光特效
    public void PlayFlashFX(){
        StartCoroutine(FlashFX());
    }
    // Start is called before the first frame update
    void Start()
    {
        health=70;
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMat = sr.material; // 记录原始的材质
        anim=GetComponent<Animator>();
        lasttime=Time.time;
        anim.SetFloat("throwtime",0);
        transform.localPosition=new UnityEngine.Vector3(0,9.5f,-4);
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 targetPosition=new UnityEngine.Vector3(mHero.transform.localPosition.x,9.5f,-4);
        transform.localPosition = UnityEngine.Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime);
        float curtime=Time.time;
        anim.SetFloat("throwtime",curtime-lasttime);
        if(curtime-lasttime>timegap)
        {
            lasttime=curtime;
            GameObject bullet=Resources.Load("Wu/Prefabs/bossBullet") as GameObject;
            UnityEngine.Vector3 pos=new UnityEngine.Vector3(transform.localPosition.x,9.5f,-1);
            bullet.transform.localPosition=pos;
            Instantiate(bullet);
        }
        UnityEngine.Vector3 heroPos=mHero.transform.localPosition;
        if(heroPos.y<-18.0f)
        {
            GameManage.sGameManage.reloadScene();
        }
    }
    
     private IEnumerator FlashFX()
    {
        sr.material = hitMat; // 切换到受击材质
        yield return new WaitForSeconds(0.1f); // 等待指定的闪光持续时间
        sr.material = originalMat; // 恢复原始材质
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name=="bossBullet(Clone)"&&Time.time-lasttime>0.5f)
        {
            Destroy(collision.gameObject);
            PlayFlashFX();
            health-=10;
            if(health==50)
            {
                gate1.SetActive(true);
                gate1.GetComponent<MoveGround>().bornTime=Time.time;
                gate2.SetActive(true);
                gate2.GetComponent<MoveGround>().bornTime=Time.time;
            }
            if(health<=0)
            {
                GameObject lian=Resources.Load("Wu/Prefabs/lianfall") as GameObject;
                UnityEngine.Vector3 pos=new UnityEngine.Vector3(transform.localPosition.x,9.5f,-3);
                Instantiate(lian,pos,transform.localRotation);
                Destroy(transform.gameObject);
                Destroy(gate1);
                Destroy(gate2);
            }
        } 
    }
    
}
   

