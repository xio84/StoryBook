using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Solution : MonoBehaviour
{
    [SerializeField] private bool solved;
    private Vector3 velocity = Vector3.zero;
    
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
    }

    // Update is called once per frame
    void Update()
    {
        bool checkX = transform.localEulerAngles.x < rotSolution.x + threshold.x && transform.localEulerAngles.x > rotSolution.x - threshold.x;
        bool checkY = transform.localEulerAngles.y < rotSolution.y + threshold.y && transform.localEulerAngles.y > rotSolution.y - threshold.y;
        bool checkZ = transform.localEulerAngles.z < rotSolution.z + threshold.z && transform.localEulerAngles.z > rotSolution.z - threshold.z;
        if (checkX && checkY && checkZ)
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
    }

    public void Rotate(int index)
    {
        if (!solved)
        {
            Vector3 eA = transform.localEulerAngles;
            switch (index)
            {
                case 0:
                    // Rotate X
                    eA.x += Time.deltaTime * rotSpeed;
                    eA.x %= 360;
                    break;
                case 1:
                    // Rotate X
                    eA.y += Time.deltaTime * rotSpeed;
                    eA.y %= 360;
                    break;
                case 2:
                    // Rotate X
                    eA.z += Time.deltaTime * rotSpeed;
                    eA.z %= 360;
                    break;
                default:
                    break;
            }
            transform.localEulerAngles = eA;
        }
    }
}
