using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    //private Rigidbody getRigidBody;
    [SerializeField] LayerMask interactLayer;
    private Interactable[] interactiveObjects;
    private float[] eachDistance;
    // Start is called before the first frame update
    void Start()
    {
        //getRigidBody = GetComponent<Rigidbody>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position,4f);
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 4f, interactLayer);
        int i = 0;
        Interactable nearest = null;
        float nearDist = 9999;
        while (i < hitColliders.Length)
        {
            float thisDist = (transform.position - hitColliders[i].transform.position).sqrMagnitude;
            if (thisDist < nearDist)
            {
                nearDist = thisDist;
                nearest = hitColliders[i].GetComponent<Interactable>();
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && nearest != null)
        {
            // nearest.DoSomething();
            Debug.Log("Interaction!");
            nearest.DoSomething();
        }
    }
}
