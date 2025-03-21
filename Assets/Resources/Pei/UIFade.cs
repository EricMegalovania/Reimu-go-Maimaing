
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UI的渐入渐出
/// </summary>
public class UIFade : MonoBehaviour {
    private float UI_Alpha = 0;        
    public float alphaSpeed = 2f;
    private CanvasGroup canvasGroup;

    public float awakeTime;

    public float startTime = 0f;
    public float endTime;
 
	// Use this for initialization
	void Start () {
        canvasGroup = GetComponent<CanvasGroup>();
        awakeTime = Time.time;
        canvasGroup.alpha = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        if(Time.time>=startTime+awakeTime && Time.time<endTime+awakeTime) UI_Alpha = 1;
        if(Time.time>=endTime+awakeTime) UI_Alpha = 0;
 
        if (UI_Alpha != canvasGroup.alpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, UI_Alpha, alphaSpeed * Time.deltaTime);
            if (Mathf.Abs(UI_Alpha - canvasGroup.alpha) <= 0.01f)
            {
                canvasGroup.alpha = UI_Alpha;
                if(UI_Alpha==0)End();
            }
        }
	}

    void End(){
        GameManage.sGameManage.changeScene("Menu", 0);
        GameManage.sGameManage.reloadScene();

    }
}