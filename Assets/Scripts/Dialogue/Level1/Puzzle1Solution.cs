﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Solution : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private Quaternion targetDeg;
    private Quaternion solutionDeg;
    
    public bool solved;
    public Transform[] children;
    public Vector3 rotSolution;
    public Vector3 threshold;
    public Vector3 finalPos;
    public float smoothTime;
    public float rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        solved = false;
        targetDeg = transform.rotation;
        solutionDeg = targetDeg;
        targetDeg *= Quaternion.Euler(-90, 0, 0);
        targetDeg *= Quaternion.Euler(0, -90, 0);
        targetDeg *= Quaternion.Euler(0, 0, -90);
        transform.rotation = targetDeg;
    }

    // Update is called once per frame
    void Update()
    {
        /*bool checkX = transform.localEulerAngles.x < rotSolution.x + threshold.x && transform.localEulerAngles.x > rotSolution.x - threshold.x;
        bool checkY = transform.localEulerAngles.y < rotSolution.y + threshold.y && transform.localEulerAngles.y > rotSolution.y - threshold.y;
        bool checkZ = transform.localEulerAngles.z < rotSolution.z + threshold.z && transform.localEulerAngles.z > rotSolution.z - threshold.z;*/
        if (solutionDeg == transform.rotation)
        {
            solved = true;
        }
        if (solved)
        {
            foreach (Transform c in children)
            {
                Vector3 target = c.localPosition;
                target.z = 0;
                c.localPosition = Vector3.SmoothDamp(c.localPosition, target, ref velocity, smoothTime);
            }
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, finalPos, ref velocity, smoothTime);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetDeg, rotSpeed * Time.deltaTime);
        }
    }

    public void Rotate(int index)
    {
        if (!solved)
        {
            switch (index)
            {
                case 0:
                    // Rotate X
                    targetDeg *= Quaternion.Euler(90, 0, 0);
                    break;
                case 1:
                    // Rotate Y
                    targetDeg *= Quaternion.Euler(0, 90, 0);
                    break;
                case 2:
                    // Rotate Z
                    targetDeg *= Quaternion.Euler(0, 0, 90);
                    break;
                default:
                    break;
            }
            Debug.Log(targetDeg + " " + solutionDeg);
        }
    }
}