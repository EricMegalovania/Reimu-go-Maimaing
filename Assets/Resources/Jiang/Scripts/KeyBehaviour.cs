using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class KeyBehaviour : MonoBehaviour
{
    public enum KeyTypes { redP,blueP,bomb};
    public TMP_Text tKeyNumber;
    public int num=1;
    private bool flag=true; //active or not
    public KeyTypes keyType=KeyTypes.redP;
    // Start is called before the first frame update
    void Start()
    {
        SetTexture();
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetTexture()
    {
        if (keyType == KeyTypes.redP)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite=Resources.Load("Jiang/Textures/RedP", typeof(Sprite)) as Sprite;
        }
        else if (keyType == KeyTypes.blueP)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Jiang/Textures/BlueP", typeof(Sprite)) as Sprite;
        }
        else //bomb
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Jiang/Textures/Bomb", typeof(Sprite)) as Sprite;
        }
    }
    void SetText()
    {
        if (num > 1) tKeyNumber.text = "" + (num);
        else tKeyNumber.text = "";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (flag==true)
        {
            Debug.Log("get keys " + num);
            Activate(false);
            LockManagement.AddKey(keyType,num);
        }
    }
    public void Activate(bool rua)
    {
        gameObject.SetActive(flag = rua);
    }
    public bool Active()
    {
        return flag;
    }
}
