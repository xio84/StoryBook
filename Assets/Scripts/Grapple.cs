using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    [SerializeField] private LineRenderer lr;
    [SerializeField] private LayerMask grabAble,clickAble;

    [SerializeField] private float maxDistance = 5f;

    private SpringJoint joint;
    private Vector3 grapplePoint;
    private Vector3 mousePos;
    private Rigidbody getRigidbody = null, conBody=null;
    
    private bool grapplePull;
    private float distanceFromPoint;

    public bool isGrappling;

    // Start is called before the first frame update
    void Start()
    {
        getRigidbody = GetComponent<Rigidbody>();
    }
       
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f,clickAble))
            {
                mousePos = hit.point;
            }
            else return;
            startGrapple(hit.point);
        }

        grapplePull = (Input.GetMouseButton(1) && isGrappling);

        if (Input.GetMouseButtonUp(0))
        {
            stopGrapple();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    private void FixedUpdate()
    {
        if (joint != null)
        {
            if (grapplePull)
            {
                joint.maxDistance = 0f;
            }
            else
            {
                joint.maxDistance = distanceFromPoint*0.8f;
            }
        }
        
    }

    private void stopGrapple()
    {
        Destroy(joint);
        isGrappling = false;
        lr.enabled = false;
    }

    private void startGrapple( Vector3 a)
    {
        Debug.Log("SHOT");
        RaycastHit hit;
        if (Physics.Raycast(getRigidbody.position, (new Vector3(a.x,a.y,0) - getRigidbody.position).normalized, out hit, maxDistance, grabAble))
        {
            grapplePoint = hit.point;
            conBody = hit.rigidbody;
            joint = gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.enableCollision = true;
            Debug.Log("Step 1");
            if (conBody != null)
            {
                joint.connectedBody = conBody;
                grapplePoint = hit.point - conBody.position;
                distanceFromPoint = Vector3.Distance(conBody.rotation * grapplePoint + conBody.position, getRigidbody.position);
                Debug.Log("Step 2");
            }else distanceFromPoint = Vector3.Distance(grapplePoint, getRigidbody.position);
            joint.connectedAnchor = grapplePoint;
            joint.maxDistance = distanceFromPoint*0.8f;
            joint.minDistance = 0.3f;
            joint.spring = 5f;
            joint.damper = 6f;
            joint.massScale = 10f;
            joint.connectedMassScale = 10f;
            isGrappling = true;
            lr.enabled = true;

            Debug.Log("Step 3");
        }
    }

    private void DrawRope()
    {
        if (joint != null)
        {
            lr.SetPosition(0, getRigidbody.position);
            if (conBody != null)
            {
                lr.SetPosition(1, conBody.rotation*grapplePoint + conBody.position);
            }else lr.SetPosition(1, grapplePoint);
        }
    }
}
