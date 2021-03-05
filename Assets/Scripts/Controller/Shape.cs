using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shape : MonoBehaviour
{
    private Controller controller;
    public float dropTimer = 0.5f;
    public bool isPause = false;
    private GameManger gameManger;

    private Button[] buttons;

    private bool isSpeed = false;
    private Transform pivot;


    private void Awake()
    {
        buttons = GameObject.Find("ControlButtons").GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(OnLeftButtonClick);
        buttons[1].onClick.AddListener(OnRightButtonClick);
        buttons[2].onClick.AddListener(OnSpeedButtonClick);
        buttons[3].onClick.AddListener(OnRotateButtonClick);
        pivot = transform.Find("Pivot").transform;

    }
    public void Init(Color color,Controller controller,GameManger gameManger)
    {
        foreach(Transform t in transform)
        {
            if (t.tag == "Block")
            {
                t.GetComponent<SpriteRenderer>().color = color;
            }
        }
        this.controller = controller;
        this.gameManger = gameManger;
    }

    public void Fall()
    {
        Vector2 pos = transform.position;
        pos.y -= 1;
        transform.position = pos;
        if (controller.model.IsValidMapPosition(transform) == false)
        {
            pos.y += 1;
            transform.position = pos;
            isPause = true;
           
           bool isClear= controller.model.PlaceShape(transform);
            if (isClear)
            {
                controller.audioManger.PlayClearLineAudio();
            }
            gameManger.FallDown();
            return;
        }
        controller.audioManger.PlayDropAudio();
    }

    public void PauseGame()
    {
        isPause = true;
    }

    public void StartGame()
    {
        isPause = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPause) return;
        if (dropTimer <= 0)
        {
            Fall();
            
            dropTimer = 0.5f;
        }
        else
        {
            if (isSpeed)
            {
                dropTimer -= Time.deltaTime * 16;
            }

            else
            {
                dropTimer -= Time.deltaTime;
            }
        }
    }

    public void OnLeftButtonClick()
    {
        if (isPause) return;
        
        Vector2 pos = transform.position;
        pos.x -= 1;
        transform.position = pos;

        if (controller.model.IsValidMapPosition(transform) == false)
        {
            pos.x += 1;
            transform.position = pos;
            return;
        }

        controller.audioManger.PlayMoveAudio();
    }


    public void OnRightButtonClick()
    {
        if (isPause) return;

        Vector2 pos = transform.position;
        pos.x += 1;
        transform.position = pos;

        if (controller.model.IsValidMapPosition(transform) == false)
        {
            pos.x -= 1;
            transform.position = pos;
            return;
        }
        controller.audioManger.PlayMoveAudio();
    }

    public void OnSpeedButtonClick()
    {
        if (isPause) return;
        isSpeed = true;
    }

    public void OnRotateButtonClick()
    {
        if (isPause) return;


        transform.RotateAround(pivot.position, Vector3.forward, 90f);
        if (controller.model.IsValidMapPosition(transform) == false)
        {
            transform.RotateAround(pivot.position, Vector3.forward, -90f);
            return;
        }
        controller.audioManger.PlayRotateAudio();
    }
}
