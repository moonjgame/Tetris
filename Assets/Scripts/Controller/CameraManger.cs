using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraManger : MonoBehaviour
{
    public Camera camera;


    public void ZoomIn()
    {
        camera.DOOrthoSize(18.5f, 0.5f);
    }

    public void ZoomOut()
    {
        camera.DOOrthoSize(15.8f, 0.5f);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
