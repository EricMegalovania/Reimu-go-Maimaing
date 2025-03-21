using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    // Start is called before the first frame update

    public ButtonCtrl startred;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.white;
        GetComponent<Renderer>().material.color *= 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter() 
    {
     
        startred.Activate(true);

    }
    private void OnMouseExit() 
    {
        startred.Activate(false);
    }
    void OnMouseDown()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

}
