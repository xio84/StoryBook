using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examinable : MonoBehaviour
{
    [SerializeField] public Camera mainCam;
    GameObject clone;

    private void Start()
    {
        clone = Instantiate(this.gameObject, new Vector3(mainCam.transform.position.x, mainCam.transform.position.y, mainCam.transform.position.z + 5), Quaternion.identity, mainCam.transform);
        clone.AddComponent<ExamineMouseRotate>();
        clone.SetActive(false);
    }

    public void StartExamine()
    {
        Debug.Log("Examining " + this.name);
        clone.SetActive(true);
        /*int i = 0;*/
        /*while (i < mainCam.transform.childCount)
        {
            if (mainCam.transform.GetChild(i).name == this.name + "(Clone)")
            {
                mainCam.transform.GetChild(i).gameObject.AddComponent<ExamineMouseRotate>();
            }
            i++;
        }*/
    }

    public void EndExamine()
    {
        Debug.Log("Examining " + this.name);
        /*int i = 0;
        while (i < mainCam.transform.childCount)
        {
            if (mainCam.transform.GetChild(i).name == this.name + "(Clone)")
            {
                Destroy(mainCam.transform.GetChild(i).gameObject);
            }
            i++;
        }*/
        clone.SetActive(false);
        Debug.Log("End Examining " + this.name + "(Clone)");
    }
}
