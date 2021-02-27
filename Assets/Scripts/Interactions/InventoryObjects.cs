using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObjects : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    public string id;
    public string desc;
    [SerializeField] Sprite picture;
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

    private void OnTriggerEnter(Collider other)
    {
        // Get player game object
        GameObject player = other.gameObject;
        PlayerInventory inv = player.GetComponent<PlayerInventory>();
        if (inv)
        {
            if (inv.ids.Count < 9)
            {
                bool success = inv.AddObject(id, picture);
                if (success)
                {
                    Destroy(gameObject);
                } else
                {
                    Debug.Log("Inventory Full");
                }
            }
        }
    }

    public void giveItem()
    {
        // Get player game object
        GameObject player = FindObjectOfType<Player>().GetComponent<Player>().gameObject;
        PlayerInventory inv = player.GetComponent<PlayerInventory>();
        if (inv)
        {
            if (inv.ids.Count < 9)
            {
                bool success = inv.AddObject(id, picture);
                if (success)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("Inventory Full");
                }
            }
        }
    }
}
