using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeMenu : MonoBehaviour
{
    [SerializeField] private GameObject spawnable1, spawnable2;
    [SerializeField] private Vector3 spawnPos;
    // Start is called before the first frame update
    private void Start()
    {
        spawnPos = new Vector3(gameObject.transform.position.x-0.5f, gameObject.transform.position.y,0);
    }

    public void RedButtonPressed()
    {
        GameObject.Instantiate(spawnable2,spawnPos, Quaternion.identity);
    }

    public void BlueButtonPressed()
    {
        GameObject.Instantiate(spawnable1, spawnPos, Quaternion.identity);
    }
}
