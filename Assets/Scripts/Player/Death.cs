using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Vector3 lastCheck;
    // Start is called before the first frame update
    void Start()
    {
        lastCheck = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Checkpoint(Vector3 check)
    {
        lastCheck = check;
    }
}
