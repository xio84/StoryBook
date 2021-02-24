using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineMouseRotate : MonoBehaviour
{
    private bool isRotating;
    private Vector3 mousePos1, mousePos2, mouseOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
            mousePos1 = Input.mousePosition;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }
    }

    void FixedUpdate()
    {
        if (isRotating)
        {
            mousePos2 = Input.mousePosition;
            mouseOffset = mousePos2 - mousePos1;
            mouseOffset = new Vector3(mouseOffset.y, -mouseOffset.x, mouseOffset.z);
            transform.Rotate(mouseOffset * 0.5f, Space.World);
            mousePos1 = mousePos2;
        }
    }
}
