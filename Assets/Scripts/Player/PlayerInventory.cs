using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int cursor;
    private bool useItem;
    private bool examineItem;
    private bool stopExamine;
    private bool interactObject;
    private bool examining;
    private InventoryUI iUI;
    private Rigidbody rigidBody;

    public LayerMask interactable;
    public GameObject inventoryUI;
    public List<Obtainable> objects;
    public int maxInv = 5;
    public float scrollSensitivity = 1;
    public float interactRadius = 4;

    public bool Examining { get => examining; set => examining = value; }

    // Start is called before the first frame update
    void Start()
    {
        objects = new List<Obtainable>();
        iUI = inventoryUI.GetComponent<InventoryUI>();
        rigidBody = GetComponent<Rigidbody>();
        Examining = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Listen for key
        useItem = Input.GetKeyDown(KeyCode.F);
        examineItem = Input.GetKeyDown(KeyCode.C);
        stopExamine = Input.GetKeyDown(KeyCode.Escape);
        interactObject = Input.GetKeyDown(KeyCode.E);

        if (interactObject && !Examining)
        {
            Debug.Log("Collecting...");
            Interact();
        }

        if (useItem && !Examining)
        {
            if (objects.Count > 0)
            {
                Use();
            }
        }
    }

    private void FixedUpdate() // TODO find alternative to slow fixedupdate
    {

        if (!Examining && examineItem && objects.Count > 0)
        {
            Examining = true;
            // Player can't move while examining items
            rigidBody.isKinematic = true;
            Obtainable oItem = objects[cursor];
            Examinable xItem = oItem.GetComponent<Examinable>();
            if (xItem)
            {
                xItem.StartExamine();
            } else
            {
                Examining = false;
                rigidBody.isKinematic = false;
            }
        } else if (stopExamine && Examining)
        {
            Examining = false;
            rigidBody.isKinematic = false;
            Obtainable oItem = objects[cursor];
            Examinable xItem = oItem.GetComponent<Examinable>();
            if (xItem)
            {
                xItem.EndExamine();
            } else
            {
                Debug.LogError("No Examinables found!");
            }
        }
    }

    // Adds item to inventory
    public bool AddObject(Obtainable obj)
    {
        if (objects.Count > maxInv) return false;
        objects.Add(obj);
        Refresh();
        return true;
    }

    // Refresh inventory
    public void Refresh()
    {
        if (iUI)
        {
            iUI.UpdateInventory(objects);
        }
        else
        {
            Debug.LogError("No Inventory UI!");
        }
    }

    // Use inventory object
    public void Use()
    {
        // Get all objects, ordered by proximity
        Collider[] targets = Physics.OverlapSphere(transform.position, interactRadius, interactable);
        if (targets.Length > 0)
        {
            Collider[] orderedByProximity = targets.OrderBy(c => Vector3.Distance(transform.position, c.transform.position)).ToArray();

            int i = 0; bool found = false;
            IInteractables iObj;
            while (i < orderedByProximity.Length && !found)
            {
                iObj = orderedByProximity[i].GetComponent<IInteractables>();
                if (iObj != null)
                {
                    if (iObj.Interact(objects[cursor].id)) found = true;
                }
                i++;
            }
            if (found)
            {
                objects.RemoveAt(cursor);
                Refresh();
            }
        }
    }

    // Interact with environment object
    public void Interact()
    {
        // Get all objects, ordered by proximity
        Collider[] targets = Physics.OverlapSphere(transform.position, interactRadius, interactable);
        Collider[] orderedByProximity = targets.OrderBy(c => Vector3.Distance(transform.position, c.transform.position)).ToArray();

        int i = 0; bool found = false;
        IObjects obj;
        while (i < orderedByProximity.Length && !found)
        {
            Debug.Log(orderedByProximity[i].ToString());
            obj = orderedByProximity[i].GetComponent<IObjects>();
            if (obj != null)
            {
                found = true;
                obj.Interact(this.gameObject);
            }
            i++;
        }
        if (!found)
        {
            Debug.Log("No obtainables!");
        }
    }

    // Switch Inventory
    public void Switch(int curs)
    {
        cursor = curs;
    }
}
