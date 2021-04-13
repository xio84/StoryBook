using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static int PauseState;
    public GameObject pauseMenuUI;

    public void loadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
