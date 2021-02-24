using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidePressurePlate : MonoBehaviour
{
    //[SerializeField] 
    private Vector3 doorPos;
    [SerializeField] private float doorLift;
    private int thingy;
    public bool open;
    public float start, stop;
    private void Start()
    {
        open = false;
        doorPos = door.transform.position;
        start = doorPos.y;
        stop = doorPos.y + doorLift;
    }

    private void Update()
    {
        if (door.transform.position.y < stop && open)
        {
            door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y + (Time.deltaTime * 5));
        } else if (door.transform.position.y > start && !open)
        {
            door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y - (Time.deltaTime * 5));
        }
    }

    [SerializeField] GameObject door;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        thingy++;
        open = true;
        // door.transform.position = new Vector3(doorPos.x,doorPos.y+doorLift,0);
    }

    private void OnTriggerExit(Collider other)
    {
        thingy--;
        if (thingy<=0)
        open = false;
            // door.transform.position = new Vector3(doorPos.x, doorPos.y,0);
    }

}
