using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unobtainable : MonoBehaviour, IObjects
{
    private GameObject p;
    private bool isExamine;
    private GameObject clone;

    public Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        isExamine = false;
        clone = Instantiate(this.gameObject, new Vector3(mainCam.transform.position.x, mainCam.transform.position.y, mainCam.transform.position.z + 5), Quaternion.identity, mainCam.transform);
        clone.AddComponent<ExamineMouseRotate>();
        clone.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isExamine && p)
        {
            EndExamine();
        }
    }

    private void StartExamine()
    {
        Debug.Log("Examining " + this.name);
        isExamine = true;
        clone.SetActive(true);
        p.GetComponent<PlayerInventory>().Examining = true;
        p.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void EndExamine()
    {
        Debug.Log("Examining " + this.name);
        isExamine = false;
        clone.SetActive(false);
        p.GetComponent<PlayerInventory>().Examining = false;
        p.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void Interact(GameObject player)
    {
        p = player;
        StartExamine();
    }
}
