using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class ScanVision : MonoBehaviour
{
    [SerializeField] Camera mainCam, blackCam, inCam;
    [SerializeField] Volume ppVol;
    private bool scanToggle;
    private UniversalAdditionalCameraData additionalMainCameraData;

    // Start is called before the first frame update
    void Start()
    {
        additionalMainCameraData = mainCam.transform.GetComponent<UniversalAdditionalCameraData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            scanToggle = !scanToggle;
            if (scanToggle)
            {
                additionalMainCameraData.SetRenderer(1);
                ppVol.enabled = true;
                blackCam.enabled = true;
                inCam.enabled = true;
            }
            else
            {
                additionalMainCameraData.SetRenderer(0);
                ppVol.enabled = false;
                blackCam.enabled = false;
                inCam.enabled = false;
            }
        }
    }
}
