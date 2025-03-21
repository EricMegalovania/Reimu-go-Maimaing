using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinWinWin : MonoBehaviour
{
    public Image img = null;
    public Transform text = null;
    private DestinationBehaviour dest = null;
    private Animator anim = null;

    private int status = -1; //Enter:0 Stay:1 Exit:2
    private const float yUp = 14.0f, scaleRotate = 0.3f, speedRotate = Mathf.PI * 1.3f;
    private const float time = 1.0f, speedA = 1.0f / time, speedP = (yUp - scaleRotate) / time;
    private float nw = 0.0f;

    private const float speedHue = 1.0f / 20.0f;
    private float _Hue, _Saturation, _Value;
    // Start is called before the first frame update
    void Start()
    {
        Color color = img.color;
        Color.RGBToHSV(color, out _Hue, out _Saturation, out _Value);
        color.a = 0;
        img.color = color;
        Vector3 p = text.position;
        p.y = yUp;
        text.position = p;
        dest = GameObject.Find("/Destination").GetComponent<DestinationBehaviour>();
        Debug.Assert(dest != null);
        anim = GameObject.Find("/AnimationWin").GetComponent<Animator>();
        Debug.Assert(anim != null);
    }
    // Update is called once per frame
    void Update()
    {
        if (status == -1) return;
        if (status == 0)
        {
            nw += Time.smoothDeltaTime;
            Color color = img.color;
            color.a = nw * speedA;
            img.color = color;
            Vector3 p = text.position;
            p.y = yUp - nw * speedP;
            text.position = p;
            if (nw > time)
            {
                nw = 0.0f;
                status = 1;
                GameObject.Find("/HeroLockpick").SetActive(false);
            }
        }
        else if (status == 1)
        {
            Vector3 p = text.position;
            nw += Time.smoothDeltaTime;
            p.x = scaleRotate * Mathf.Sin(speedRotate * nw);
            p.y = scaleRotate * Mathf.Cos(speedRotate * nw);
            _Hue += Time.deltaTime * speedHue;
            if (_Hue > 1) _Hue -= 1;
            img.color = Color.HSVToRGB(_Hue, _Saturation, _Value);
            if (Input.anyKeyDown)
            {
                status = 2;
                nw = 0.0f;
            }
            text.position = p;
        }
        else
        {
            nw += Time.smoothDeltaTime;
            Color color = img.color;
            color.a = 1.0f - nw * speedA;
            img.color = color;
            Vector3 p = text.position;
            p.y += Time.smoothDeltaTime * speedP;
            text.position = p;
            if (nw > time)
            {
                dest.LoadNextScene();
            }
        }
    }
    public void WinEnter()
    {
        GameObject.Find("/CanvasKey").SetActive(false);
        GameObject.Find("/CanvasAutoUnlock").SetActive(false);
        status = 0;
        nw = 0.0f;
        Vector3 p = GameObject.Find("/HeroLockpick").transform.position;
        p.z = -3;
        GameObject.Find("/AnimationWin").transform.position = p;
        anim.SetTrigger("IsWin");
    }
    public bool IsWin()
    {
        return status != -1;
    }
}
