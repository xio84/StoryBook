﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Vector3 checkpoint;
    private PlayerInventory pI;
    private InventoryUI iU;
    private bool iUIshow;
    private bool pause;

    public GameObject Player;
    public GameObject inventoryUI;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pI = Player.GetComponent<PlayerInventory>();
        iU = inventoryUI.GetComponent<InventoryUI>();
        iUIshow = false;
        pause = false;
        CloseInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !pause)
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
        else if (Input.GetKeyDown(KeyCode.Escape) && !iUIshow)
        {
            if (pause)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
            pause = !pause;
        }
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

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Unpause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
