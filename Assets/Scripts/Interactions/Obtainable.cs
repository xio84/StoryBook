using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obtainable : MonoBehaviour, IObjects
{
    private Rigidbody m_Rigidbody;
    public string id;
    public string desc;
    [SerializeField] public Sprite picture;
    public int turnSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Turn the object
        float turn = turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        m_Rigidbody.MoveRotation(turnRotation * m_Rigidbody.rotation);
    }

    public void Interact(GameObject player)
    {
        // Get player game object
        PlayerInventory inv = player.GetComponent<PlayerInventory>();
        if (inv)
        {
            if (inv.objects.Count < 5)
            {
                bool success = inv.AddObject(this);
                if (success)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    Debug.Log("Inventory Full");
                }
            }
        }
    }
}
