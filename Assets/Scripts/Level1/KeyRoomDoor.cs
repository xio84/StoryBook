using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRoomDoor : MonoBehaviour, IObjects
{
    public bool open;
    public GameObject pivot;
    private bool opened;
    public Quaternion rotTarget;
    public Quaternion rotBegin;
    public float speed;

    public void Interact(GameObject player)
    {
        open = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        open = false;
        rotBegin = this.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (open && !opened)
        {
            if (!(transform.localRotation.eulerAngles.y < rotTarget.eulerAngles.y + 5 && transform.localRotation.eulerAngles.y > rotTarget.eulerAngles.y - 5))
            {
                transform.RotateAround(pivot.transform.position, Vector3.up, Time.deltaTime * speed);
            }
        }
    }
}
