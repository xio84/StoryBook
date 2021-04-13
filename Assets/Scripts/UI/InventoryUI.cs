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
    public Text textName;
    public Text location;

    // Start is called before the first frame update
    void Start()
    {

        foreach (Image img in invImages)
        {
            img.color = new Color(0, 0, 0, 0);
        }

        foreach (Image img in partImages)
        {
            img.color = new Color(0, 0, 0, 0);
        }

        description.text = "";
        location.text = "";
        textName.text = "";

        int i = 0;
        // Update all invImages
        foreach (Obtainable o in inventory)
        {
            Image image = invImages[i];
            image.sprite = o.picture;
            image.color = new Color(255, 255, 255, 255);
            i++;
        }
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

        // Reset all images
        foreach (Image img in invImages)
        {
            img.color = new Color(0, 0, 0, 0);
        }

        // Reset dedscription text
        description.text = "";
        location.text = "";
        textName.text = "";

        // Update all invImages
        foreach (Obtainable o in inventory)
        {
            Image image = invImages[i];
            image.sprite = o.picture;
            image.color = new Color(255, 255, 255, 255);
            i++;
        }

    }

    // Highlight item
    public void Highlight(int cursor)
    {
        Debug.Log("Highlighting");
        if (cursor < inventory.Count && cursor >= 0)
        {
            description.text = inventory[cursor].desc;
            textName.text = inventory[cursor].oName;
            location.text = "Obtained from: " + inventory[cursor].location;
        }
        else
        {
            description.text = "";
            location.text = "";
            textName.text = "";
        }
    }
}
