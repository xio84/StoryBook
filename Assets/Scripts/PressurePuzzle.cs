using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePuzzle : MonoBehaviour
{
    [SerializeField] private float doorLift;
    [SerializeField] GameObject door;
    private string key = "231";
    private string answer = "";
    public bool isSequence;
    public bool isOpen;

    public void addAnswer(string str)
    {
        if (answer.Contains(str))
        {
            // do nothing
        }
        else
        {
            answer += str;
        }
    }

    public void resetAnswer()
    {
        answer = "";
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }
    */

    // Update is called once per frame
    void Update()
    {
        if (isSequence)
        {
            if (key == answer)
            {
                door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y + (Time.deltaTime * 5));
                isOpen = true;
            }
            else
            {
                if (answer.Length == 3 && key != answer)
                {
                    Debug.Log("FAILED!!");
                }
            }
        }
        else
        {
            if (answer.Length == 3)
            {
                door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y + (Time.deltaTime * 5));
                isOpen = true;
            }
        }
    }
    
}
