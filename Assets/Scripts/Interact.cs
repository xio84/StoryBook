using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private Rigidbody getRigidBody;
    [SerializeField] LayerMask interactLayer;
    private GameObject[] interactiveObjects;
    private float[] eachDistance;
    // Start is called before the first frame update
    void Start()
    {
        getRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
