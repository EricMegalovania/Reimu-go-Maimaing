using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using static KeyBehaviour;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

/// <summary>
/// 
/// </summary>
public class LockBehaviour : MonoBehaviour
{
    public enum LockTypes { red, blue };
    public TMP_Text tLockNumber;
    public int num = 1;
    private bool flag = true; //active or not
    public LockTypes lockType = LockTypes.red;
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
        if (lockType == LockTypes.red)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Jiang/Textures/RedLock", typeof(Sprite)) as Sprite;
        }
        else //blue
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Jiang/Textures/BlueLock", typeof(Sprite)) as Sprite;
        }
    }
    void SetText()
    {
        if (num < 10) tLockNumber.text = "" + (num);
        else tLockNumber.text = "¡Þ";
    }
    /// <summary>
    /// Edit -> Project Settings -> Physics
    /// set only collision between Layer/Hero(3) and Layer/Lock_Ground(7)
    /// cancel L7 & L7 's collision as well
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (flag == true && LockManagement.GetAutoUnlock())
        {
            if (LockManagement.GetsBomb())
            {
                Activate(false);
                LockManagement.ResetsBomb();
                LockManagement.AddKey(KeyTypes.bomb, -1);
                return;
            }
            if (lockType == LockTypes.red)
            {
                if (LockManagement.redP >= num)
                {
                    Activate(false);
                    LockManagement.AddKey(KeyTypes.redP, -num);
                }
            }
            else //blue
            {
                if (LockManagement.blueP >= num)
                {
                    Activate(false);
                    LockManagement.AddKey(KeyTypes.blueP, -num);
                }
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        OnCollisionEnter2D(collision);
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
