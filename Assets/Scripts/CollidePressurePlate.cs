using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidePressurePlate : MonoBehaviour
{
    //[SerializeField] 
    private Vector3 doorPos;
    [SerializeField] private float doorLift;
    private int thingy;
    private void Start()
    {
        doorPos = door.transform.position;
    }

    [SerializeField] GameObject door;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        thingy++;
        door.transform.position = new Vector3(doorPos.x,doorPos.y+doorLift,0);
    }

    private void OnTriggerExit(Collider other)
    {
        thingy--;
        if (thingy<=0)
            door.transform.position = new Vector3(doorPos.x, doorPos.y,0);
    }

}
