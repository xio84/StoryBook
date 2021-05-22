using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float smoothTime;
    public Vector3 posOffset; // Camera positiion offset
    public List<Vector3> checkpoints;

    private Vector3 camPos;
    private bool kinematicX;
    private bool kinematicY;
    private bool kinematicZ;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        camPos = player.transform.position;
        kinematicX = false;
        kinematicY = false;
        kinematicZ = false;
        camPos += posOffset;
        transform.position = camPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (!kinematicX)
        {
            camPos.x = player.transform.position.x + posOffset.x;
        }
        if (!kinematicY)
        {
            camPos.y = player.transform.position.y + posOffset.y;
        }
        if (!kinematicZ)
        {
            camPos.z = player.transform.position.z + posOffset.z;
        }

        // Move camera to target
        transform.position = Vector3.SmoothDamp(transform.position, camPos, ref velocity, smoothTime);
    }

    // Custom static positions
    public void Kinemation(int index)
    {
        switch (index)
        {
            case 0:
                // Puzzle 1
                if (index < checkpoints.Count)
                {
                    kinematicX = true;
                    camPos = checkpoints[index];
                }
                break;
            default:
                kinematicX = false;
                kinematicY = false;
                kinematicZ = false;
                break;
        }
    }
}
