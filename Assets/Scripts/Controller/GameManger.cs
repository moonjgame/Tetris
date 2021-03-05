using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    private bool isPause = true;
    public Shape[] shapes;
    public Color[] colors;
    public Shape  currentShape=null;
    public Controller controller;
    public GameObject blockHolder;
    void Start()
    {
        controller = GetComponent<Controller>();
    }

    public void StartGame()
    {
        if (currentShape != null)
            currentShape.StartGame();
        isPause = false;
    }
    public void PauseGame()
    {
        if (currentShape != null)
            currentShape.PauseGame();
        isPause = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isPause) return;
        if (currentShape == null)
        {
            SpawnShape();
        }
        

    }

    public void SpawnShape()
    {
        currentShape = Instantiate(shapes[Random.Range(0, shapes.Length)]);
        currentShape.Init(colors[Random.Range(0, colors.Length)],controller,this);
        currentShape.transform.SetParent(blockHolder.transform);
    }

    public void FallDown()
    {
        if (controller.model.isUpdateScore)
        {
            controller.view.UpdateScoreUI(controller.model.Score, controller.model.BestScore);
        }

       foreach(Transform child in blockHolder.transform)
        {
            if (child.childCount <= 1)
            {
                Destroy(child.gameObject);
            }
        }
      
        if (controller.model.IsGameOver())
        {
           
            PauseGame();
            controller.view.ShowGameOverUI(controller.model.Score);
        } 
          currentShape = null;

    }

    public void ClearCurrentShape()
    {
        if (currentShape != null)
        {
            Destroy(currentShape.gameObject);
            currentShape = null;
        }
    }
}
