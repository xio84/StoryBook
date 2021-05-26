using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftButton : MonoBehaviour, IObjects, IInteractables
{
    public GameObject lift;
    public float ground;
    public float floor1;
    public float speed;
    public string keyID;
    public Material unlocked;

    private bool locked;
    private bool goDown;
    private GameObject p;

    // Start is called before the first frame update
    void Start()
    {
        locked = true;
        goDown = false;
        floor1 = lift.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!locked)
        {
            if (goDown && lift.transform.position.y > ground && p != null)
            {
                // Move Lift
                Vector3 target = lift.transform.position;
                target.y -= Time.deltaTime * speed;
                lift.transform.position = target;

                // Move Player
                target = p.transform.position;
                target.y -= Time.deltaTime * speed;
                p.transform.position = target;
            } else if (!goDown && lift.transform.position.y < floor1 && p != null)
            {
                // Move Lift
                Vector3 target = lift.transform.position;
                target.y += Time.deltaTime * speed;
                lift.transform.position = target;

                // Move Player
                target = p.transform.position;
                target.y += Time.deltaTime * speed;
                p.transform.position = target;
            }
        }
    }

    public void Unlock()
    {
        locked = false;
    }

    public void Interact(GameObject player)
    {
        if (!locked)
        {
            Debug.Log("Going Down/up");
            p = player;
            goDown = !goDown;
        }
    }

    public bool Interact(string key)
    {
        if (key == keyID)
        {
            locked = false;
            MeshRenderer mr = this.GetComponent<MeshRenderer>();
            mr.material = unlocked;
            return true;
        } 
        else
        {
            return false;
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
}
