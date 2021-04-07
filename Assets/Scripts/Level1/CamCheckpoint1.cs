using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCheckpoint1 : MonoBehaviour
{
    private CameraController cam;

    public int index;

    private void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            // Is Player
            cam.Kinemation(index);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            // Is Player
            cam.Kinemation(-1);
        }
    }
}
