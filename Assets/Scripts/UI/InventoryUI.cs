using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private List<Obtainable> inventory;

    public List<Image> invImages;
    public List<Image> partImages;
    public Text description;


    // Start is called before the first frame update
    void Start()
    {

        foreach (Image i in invImages)
        {
            i.color = new Color(0, 0, 0, 0);
        }

        foreach (Image i in partImages)
        {
            i.color = new Color(0, 0, 0, 0);
        }

        description.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Added obtainables
    public void UpdateInventory(List<Obtainable> obj)
    {
        int i = 0;
        inventory = obj;

        // Update all invImages
        foreach (Obtainable o in inventory)
        {
            Image image = invImages[i];
            image.sprite = o.picture;
            image.color = new Color(255, 255, 255, 255);
        }

    }

    // Highlight item
    public void Highlight(int cursor)
    {
        Debug.Log("Highlighting");
        if (cursor < inventory.Count && cursor >= 0)
        {
            description.text = inventory[cursor].desc;
        }
        else
        {
            description.text = "";
        }
    }
}
