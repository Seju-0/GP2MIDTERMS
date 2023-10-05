using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color[] colors;
    private int currentColorIndex = 0; 

    private Renderer renderer; 

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = colors[currentColorIndex]; 
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CycleToNextColor();
        }
    }

    private void CycleToNextColor()
    {
        currentColorIndex = (currentColorIndex + 1) % colors.Length; 
        renderer.material.color = colors[currentColorIndex]; 
    }
}
