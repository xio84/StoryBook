using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidePressurePlate : MonoBehaviour
{
    //[SerializeField] 
    public string id;
    private Vector3 doorPos;
    [SerializeField] private float doorLift;
    [SerializeField] GameObject pressurePlate;
    public bool open;
    public float start, stop;
    
    private void Start()
    {
        open = false;
        doorPos = door.transform.position;
        start = doorPos.y;
        stop = doorPos.y + doorLift;
    }

    [SerializeField] GameObject door;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (id == "0")
        {
            pressurePlate.GetComponent<PressurePuzzle>().resetAnswer();
        }
        else
        {
            pressurePlate.GetComponent<PressurePuzzle>().addAnswer(id);
            Debug.Log("id: " + id + "Pressed");
        }
        
        // door.transform.position = new Vector3(doorPos.x,doorPos.y+doorLift,0);
    }

}
