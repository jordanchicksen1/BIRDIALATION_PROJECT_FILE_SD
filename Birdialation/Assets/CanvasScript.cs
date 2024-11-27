using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    private Canvas canvas;
    private Camera Cam;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        Cam = Camera.main;
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Cam;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
