using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static KeyBehaviour;

public class LockManagement : MonoBehaviour
{
    static public Transform pHero; //position_hero
    static float yOff = 0.0f;
    private const float yOffScale = 0.2f, yOffSpeed = 0.2f;
    static bool rYOff = true; //is y_off_rising
    static bool autoUnlock = true;
    static private KeysAndLocksSetterBehaviour kls = null;

    static private TMP_Text tRedP = null, tBlueP = null, tBomb = null;
    static private bool sBomb = false; //status_bomb
    static public int redP, blueP, bomb;

    static private Image CanUnlock, CantUnlock;

    // Start is called before the first frame update
    void Start()
    {
        InitStatic(); Init();
        Debug.Assert(tRedP != null);
        Debug.Assert(tBlueP != null);
        Debug.Assert(tBomb != null);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            autoUnlock ^= true;
            Debug.Log("enter shift "+autoUnlock);
            SetImgAutoUnlock();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            kls.Undo();
            SetTexts();
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            kls.Redo();
            SetTexts();
        }
        if (bomb == 0)
        {
            ResetsBomb();
        }
        if (Input.GetKeyDown(KeyCode.X) && bomb > 0)
        {
            sBomb ^= true;
        }
        if (rYOff == true)
        {
            yOff += yOffSpeed * Time.smoothDeltaTime;
            if (yOff > yOffScale)
            {
                yOff = yOffScale;
                rYOff = false;
            }
        }
        else
        {
            yOff -= yOffSpeed * Time.smoothDeltaTime;
            if (yOff < -yOffScale)
            {
                yOff = -yOffScale;
                rYOff = true;
            }
        }
        Vector3 p = pHero.position;
        p.y += 1.5f + yOff;
        p.z = 1;
        transform.position = p;
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        if (GetsBomb())
        {
            color.a = 0.2f;
        }
        else
        {
            color.a = 0.0f;
        }
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }
    static void InitStatic()
    {
        pHero = Camera.main.GetComponent<CameraMove>().mHero.GetComponent<Transform>();
        redP = 0; blueP = 0; bomb = 0;
        kls = GameObject.Find("/KeysAndLocksSetter").GetComponent<KeysAndLocksSetterBehaviour>();
        kls.Init();
        autoUnlock = true;
        tRedP = GameObject.Find("/CanvasKey/RedPNum").GetComponent<TMP_Text>();
        tBlueP = GameObject.Find("/CanvasKey/BluePNum").GetComponent<TMP_Text>();
        tBomb = GameObject.Find("/CanvasKey/BombNum").GetComponent<TMP_Text>();
        SetTexts();
        CanUnlock = GameObject.Find("/CanvasAutoUnlock/CanUnlock").GetComponent<Image>();
        CantUnlock = GameObject.Find("/CanvasAutoUnlock/CantUnlock").GetComponent<Image>();
        SetImgAutoUnlock();
    }
    void Init()
    {
    }
    //static void S
    static void SetTexts()
    {
        tRedP.text = "×" + redP;
        tBlueP.text = "×" + blueP;
        tBomb.text = "×" + bomb;
    }
    static void SetImgAutoUnlock()
    {
        if (autoUnlock)
        {
            Color c=CanUnlock.color;
            c.a = 1.0f;
            CantUnlock.color = c;
            c=CantUnlock.color;
            c.a = 0.0f;
            CantUnlock.color = c;
        }
        else
        {
            Color c = CanUnlock.color;
            c.a = 0.0f;
            CantUnlock.color = c;
            c = CantUnlock.color;
            c.a = 1.0f;
            CantUnlock.color = c;
        }

    }
    static public void AddKey(KeyTypes keyType, int x)
    {
        if (keyType == KeyTypes.redP)
        {
            redP += x;
        }
        else if (keyType == KeyTypes.blueP)
        {
            blueP += x;
        }
        else
        {
            bomb += x;
        }
        SetTexts();
        kls.Push();
    }
    static public void ResetsBomb()
    {
        sBomb = false;
    }
    static public void SetsBomb()
    {
        sBomb = true;
    }
    static public bool GetsBomb()
    {
        return sBomb;
    }
    static public bool GetAutoUnlock()
    {
        return autoUnlock;
    }
}
