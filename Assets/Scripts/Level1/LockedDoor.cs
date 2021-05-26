using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour, IInteractables, IObjects
{
    public bool locked;
    public bool open;
    public GameObject pivot;

    private bool opened;
    private BoxCollider col;

    public string keyID;
    public Quaternion rotTarget;
    public Quaternion rotBegin;
    public float speed;

    public void Interact(GameObject player)
    {
        if (!locked)
        open = !open;
    }

    // Start is called before the first frame update
    void Start()
    {
        locked = true;
        col = this.GetComponent<BoxCollider>();
        opened = false;
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
                col.enabled = false;
            }
            else
            {
                opened = true;
            }
        }
        if (!open && opened)
        {
            if (!(transform.localRotation.eulerAngles.y < rotBegin.eulerAngles.y + 5 && transform.localRotation.eulerAngles.y > rotBegin.eulerAngles.y - 5))
            {
                transform.RotateAround(pivot.transform.position, Vector3.down, Time.deltaTime * speed);
                col.enabled = false;
            }
            else
            {
                opened = false;
                col.enabled = true;
            }
        }
    }

    public int Think()
    {
        if (locked)
        {
            return 1;
        } else
        {
            return 0;
        }
    }

    public bool Interact(string key)
    {
        if (keyID == key)
        {
            locked = false;
            return true;
        } else
        {
            return false;
        }
    }
}
