using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftButton : MonoBehaviour, IObjects
{
    public GameObject lift;
    public float ground;
    public float floor1;

    private bool locked;
    private bool goDown;

    // Start is called before the first frame update
    void Start()
    {
        locked = false;
        goDown = false;
        floor1 = lift.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (goDown && lift.transform.position.y > ground)
        {
            Vector3 target = lift.transform.position;
            target.y -= Time.deltaTime;
            lift.transform.position = target;
        } else if (!goDown && lift.transform.position.y < floor1)
        {
            Vector3 target = lift.transform.position;
            target.y += Time.deltaTime;
            lift.transform.position = target;
        }
    }

    public void Unlock()
    {
        locked = false;
    }

    public void Interact(GameObject player)
    {
        Debug.Log("Going Down/up");
        goDown = !goDown;
    }
}
