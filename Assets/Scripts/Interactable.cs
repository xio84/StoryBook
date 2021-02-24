using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isActive=false,isExamine=false;
    [SerializeField] private GameObject InteractCanvas;
    [SerializeField] private Camera mainCam;

    public virtual void DoSomething()
    {
        Debug.Log("Doing something to "+this.name);
    }

    private void StartExamine()
    {
        Debug.Log("Examining "+this.name);
        setInactive();
        isExamine = true;
        Instantiate(this.gameObject,new Vector3 (mainCam.transform.position.x, mainCam.transform.position.y,mainCam.transform.position.z+5), Quaternion.identity, mainCam.transform);
        int i = 0;
        while (i < mainCam.transform.childCount)
        {
            if (mainCam.transform.GetChild(i).name == this.name + "(Clone)")
            {
                mainCam.transform.GetChild(i).gameObject.AddComponent<ExamineMouseRotate>();
            }
            i++;
        }
    }

    private void EndExamine()
    {
        Debug.Log("Examining " + this.name);
        setActive();
        int i = 0;
        while(i< mainCam.transform.childCount)
        {
            if (mainCam.transform.GetChild(i).name == this.name + "(Clone)")
            {
                Destroy(mainCam.transform.GetChild(i).gameObject);
            }
            i++;
        }
        Debug.Log("End Examining " + this.name + "(Clone)");
        isExamine = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isActive)
        {
            DoSomething();
        }

        if (Input.GetKeyDown(KeyCode.F) && isActive && !isExamine)
        {
            StartExamine();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isExamine)
        {
            EndExamine();
        }
    }

    public void setActive()
    {
        isActive = true;
        Instantiate(InteractCanvas, this.transform);
        gameObject.transform.GetComponentsInChildren<TMPro.TextMeshProUGUI>()[0].text = this.name;
        
    }

    public void setInactive()
    {
        isActive = false;
        Destroy(gameObject.transform.GetChild(0).gameObject);
    }
}
