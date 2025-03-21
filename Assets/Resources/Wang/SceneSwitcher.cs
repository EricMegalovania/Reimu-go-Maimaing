using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject GameScene1;
    public GameObject GameScene2;
    public GameObject whiteOverlay;
    public Camera mainCamera;
    public GameObject button;
    public GameObject box;
    public Vector2 targetPosition1;
    public Vector2 targetPosition2;

    public float FadeInDuration = 0.05f;
    public float FadeOutDuration = 0.25f;
    public float zoomScale = 1.1f;

    private bool isScene1Active = true;
    private enum State { None, FadeIn, Switch, FadeOut }
    private State currentState = State.None;
    private Material WhiteMaterial;
    private float timer;
    private float initialCameraSize;
    private Vector2 initialButtonPosition;
    private Vector2 initialBoxPosition;

    // Start is called before the first frame update
    void Start()
    {
        //初始状态
        GameScene1.SetActive(isScene1Active);
        GameScene2.SetActive(!isScene1Active);

        // 获取材质实例（避免修改原始材质）
        Renderer renderer = whiteOverlay.GetComponent<Renderer>();
        WhiteMaterial = new Material(renderer.material);
        renderer.material = WhiteMaterial;
        
        // 初始透明
        SetAlpha(0);

        //获取box和button位置
        initialButtonPosition = button.transform.position;

        initialCameraSize = mainCamera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        ProcessTransition();
    }

    void HandleInput()
    {
        if (currentState == State.None && Input.GetMouseButtonDown(1))
        {
            if(isScene1Active)
                initialBoxPosition = box.transform.position;
            buttonControl BC = button.GetComponent<buttonControl>();
            if (isScene1Active)
            {
                if (BC.IsPush==1)
                {
                    float speed = 10000f;
                    BC.transform.position = Vector2.Lerp(transform.position, targetPosition1, speed * Time.deltaTime);
                    box.transform.position = Vector2.Lerp(transform.position, targetPosition1, speed * Time.deltaTime);
                }
                else
                {
                    float speed = 10000f;
                    BC.transform.position = Vector2.Lerp(transform.position, targetPosition1, speed * Time.deltaTime);
                    box.transform.position = Vector2.Lerp(transform.position, targetPosition2, speed * Time.deltaTime);
                }
            }
            else
            {
                float speed = 10000f;
                BC.transform.position = Vector2.Lerp(transform.position, initialButtonPosition, speed * Time.deltaTime);
                box.transform.position = Vector2.Lerp(transform.position, initialBoxPosition, speed * Time.deltaTime);
            }
            StartTransition();
        }
    }

    void StartTransition()
    {
        currentState = State.FadeIn;
        timer = 0;
    }

    void ProcessTransition()
    {
        switch (currentState)
        {
            case State.FadeIn:
                UpdateTransition(FadeInDuration, State.Switch, 
                                 startAlpha: 0, endAlpha: 0.4f,
                                 startZoom: initialCameraSize, 
                                 endZoom: initialCameraSize * zoomScale);
                break;

            case State.Switch:
                SwitchScene();
                currentState = State.FadeOut;
                timer = 0;
                break;

            case State.FadeOut:
                UpdateTransition(FadeOutDuration, State.None,
                                 startAlpha: 0.4f, endAlpha: 0,
                                 startZoom: initialCameraSize * zoomScale,
                                 endZoom: initialCameraSize);
                break;
        }
    }

    void UpdateTransition(float duration, State nextState, 
                         float startAlpha, float endAlpha,
                         float startZoom, float endZoom)
    {
        timer += Time.deltaTime;
        float progress = Mathf.Clamp01(timer / duration);

        // 同步更新透明度与缩放
        float currentAlpha = Mathf.Lerp(startAlpha, endAlpha, progress);
        float currentZoom = Mathf.Lerp(startZoom, endZoom, progress);
        
        SetAlpha(currentAlpha);
        SetCameraZoom(currentZoom);

        if (timer >= duration)
        {
            currentState = nextState;
            SetAlpha(endAlpha);
            SetCameraZoom(endZoom); // 确保最终值准确
        }
    }


    void SwitchScene()
    {
        isScene1Active = !isScene1Active;
        GameScene1.SetActive(isScene1Active);
        GameScene2.SetActive(!isScene1Active);
    }

    void SetAlpha(float Alpha)
    {
        Color color = WhiteMaterial.color;
        color.a = Alpha;
        WhiteMaterial.color = color;
    }

    void SetCameraZoom(float zoomValue)
    {
        mainCamera.orthographicSize = zoomValue;
    }
}
