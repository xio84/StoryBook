using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Press : MonoBehaviour
{
    private bool trigger;
    public Puzzle1Solution sol;
    public int index;
    private void Start()
    {
        trigger = false;
    }

    private void Update()
    {
        if (trigger)
        {
            sol.Rotate(index);
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            trigger = true;
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            trigger = false;
        }
    }
}
