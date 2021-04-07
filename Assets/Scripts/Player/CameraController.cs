using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float smoothTime;
    public List<Vector3> checkpoints;

    private Vector3 camPos;
    private bool kinematicX;
    private bool kinematicY;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        camPos = player.transform.position;
        kinematicX = false;
        kinematicY = false;
        camPos.y += 1.8f;
        camPos.z -= 4.8f;
        transform.position = camPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (!kinematicX)
        {
            camPos.x = player.transform.position.x;
        }
        if (!kinematicY)
        {
            camPos.y = player.transform.position.y + 1.8f;
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
                break;
        }
    }
}
