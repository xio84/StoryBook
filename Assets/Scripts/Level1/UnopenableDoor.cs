using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnopenableDoor : MonoBehaviour
{
    public bool open;
    public GameObject pivot;
    private bool opened;
    private BoxCollider col;

    public Quaternion rotTarget;
    public Quaternion rotBegin;
    public float speed;

    public void Open()
    {
        open = !open;
    }

    // Start is called before the first frame update
    void Start()
    {
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
        }
    }
}
