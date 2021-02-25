using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static int PauseState;
    public GameObject pauseMenuUI;

    private void Start()
    {
        setPauseState(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            setPauseState(3);
        }
    }

    public void setPauseState(int state)
    {
        if (state == 0)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
        else if (state == 3)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
