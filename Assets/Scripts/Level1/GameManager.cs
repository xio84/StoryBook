using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Vector3 checkpoint;
    private PlayerInventory pI;
    private InventoryUI iU;
    private bool iUIshow;

    public GameObject Player;
    public GameObject inventoryUI;
    // Start is called before the first frame update
    void Start()
    {
        pI = Player.GetComponent<PlayerInventory>();
        iU = inventoryUI.GetComponent<InventoryUI>();
        iUIshow = false;
        CloseInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (iUIshow)
            {
                CloseInventory();
            } else
            {
                ShowInventory();
            }
            iUIshow = !iUIshow;
        }
        // TODO integrate pause menu with GameManager
    }

    public void Death()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Equip(int cursor)
    {
        pI.Switch(cursor);
        CloseInventory();
    }

    public void CloseInventory()
    {
        Time.timeScale = 1;
        inventoryUI.SetActive(false);
    }

    public void ShowInventory()
    {
        inventoryUI.SetActive(true);
        Time.timeScale = 0;
    }
}
