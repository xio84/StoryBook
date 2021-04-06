using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Vector3 lastCheck;

    public GameManager level;
    public float outOfBoundsYBot;
    // Start is called before the first frame update
    void Start()
    {
        lastCheck = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < outOfBoundsYBot)
        {
            level.Death();
        }
    }

    void Checkpoint(Vector3 check)
    {
        lastCheck = check;
    }
}
