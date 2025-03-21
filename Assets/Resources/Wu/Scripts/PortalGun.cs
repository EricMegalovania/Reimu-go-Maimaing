using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    private string bulletType="Blue";
    public Collider2D ground;
    [SerializeField]
    private int numBullet;
    public GameObject mHero;
    public GameObject PortalYellow;
    public GameObject PortalBlue;
    // Start is called before the first frame update
    void Start()
    {
        numBullet=0;
    }

    // Update is called once per frame
    private void shoot()
    {
        GameObject bullet=Resources.Load("Wu/Prefabs/PortalBullet") as GameObject;
        bullet.GetComponent<PortalBullet>().portalGun=transform.GameObject();
        bullet.transform.localPosition=transform.localPosition;
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.z));
        Vector3 relativePos=worldPos-transform.localPosition;
        relativePos.z=0;
        bullet.GetComponent<PortalBullet>().direct=relativePos.normalized;
        bullet.GetComponent<PortalBullet>().ground=ground;
        if(bulletType=="Blue") bullet.GetComponent<PortalBullet>().YorB=false;
        else bullet.GetComponent<PortalBullet>().YorB=true;
        Instantiate(bullet, transform.position, transform.rotation);
        numBullet=1;
    }
    void Update()
    {
        transform.localPosition=mHero.transform.localPosition+new Vector3(0,0.9f,0);
        if(numBullet==0)
        {
            if(Input.GetMouseButtonDown(1))
            {
                bulletType="Yellow";
                shoot();
            }
            else if(Input.GetMouseButtonDown(0))
            {
                bulletType="Blue";
                shoot();
            }
        }
    }

    public void setPortal(bool isSet,bool YorB,Vector3 Pos,int PortalType){
        numBullet=0;
        if(isSet)
        {
            GameObject curPortal;
            if(YorB)
            {
                curPortal=PortalYellow;
            }
            else{
                curPortal=PortalBlue;
            }
            curPortal.SetActive(false);
            curPortal.transform.localPosition=Pos;
            curPortal.GetComponent<Portal>().portalType=PortalType;
            if(PortalType%2==0) curPortal.transform.localRotation = Quaternion.Euler(0,0,0);
            else curPortal.transform.localRotation = Quaternion.Euler(0,0,90);
            curPortal.SetActive(true);
        }
    }
}
