using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Press : MonoBehaviour, IObjects
{
    public Puzzle1Solution sol;
    public int index;

    private void Update()
    {
        if (sol.solved)
        {
            GetComponent<Collider>().enabled = false;
        }
    }

    public void Interact(GameObject player)
    {
        sol.Rotate(index);
    }

    public int Think()
    {
        if (sol.solved)
        {
            return -1;
        } else
        {
            return 0;
        }
    }
}
