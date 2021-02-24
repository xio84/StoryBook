using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int cursor;
    private float cursorDelta;
    private bool useItem;
    private InventoryUI iUI;

    public LayerMask interactable;
    public GameObject inventoryUI;
    public List<string> ids;
    public List<Sprite> pics;
    public int maxInv = 7;
    public float scrollSensitivity = 1;
    public float interactRadius = 4;
  
    // Start is called before the first frame update
    void Start()
    {
        cursor = 0;
        cursorDelta = cursor;
        ids = new List<string>();
        pics = new List<Sprite>();
        iUI = inventoryUI.GetComponent<InventoryUI>();
    }

    // Update is called once per frame
    void Update()
    {
        cursorDelta += Input.GetAxis("Mouse ScrollWheel");
        // Listen for key
        useItem = Input.GetKeyUp(KeyCode.F);
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(cursorDelta - cursor) >= 1.0f)
        {
            Scroll();
        }

        if (useItem)
        {
            Use();
        }
    }

    // Adds item to inventory
    public bool AddObject(string id, Sprite pic)
    {
        if (ids.Count > maxInv) return false;
        ids.Add(id);
        pics.Add(pic);
        Refresh();
        return true;
    }

    // Refresh inventory
    public void Refresh()
    {
        if (iUI)
        {
            iUI.UpdateInventory(pics);
        }
        else
        {
            Debug.LogError("No Inventory UI!");
        }
    }

    // Scroll inventory
    public void Scroll()
    {
        if (ids.Count > 0)
        {
            cursor = Mathf.Abs(Mathf.RoundToInt(cursorDelta) % ids.Count);
            iUI.Scroll(cursor);
        }
    }

    // Use inventory object
    public void Use()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, interactRadius, interactable);
        int i = 0; bool found = false;
        while (i < targets.Length && !found)
        {
            IInteractables iObj = targets[i].GetComponent<IInteractables>();
            if (iObj.Interact(ids[cursor])) found = true;
            i++;
        }
        if (found)
        {
            ids.RemoveAt(cursor);
            pics.RemoveAt(cursor);
            Refresh();
        }
    }
}
