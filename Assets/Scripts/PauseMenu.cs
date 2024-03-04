using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] GameObject pauseMenu;
    public EventSystem eventSystem;
    public Button buttonToFocus;
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Pause()
    {
       
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        EventSystem.current.SetSelectedGameObject(buttonToFocus.gameObject);
        Debug.Log("Worked");
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Unpaused");
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenu.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
        FindObjectOfType<AudioManager>().Play("Button");
    }
    public void Quit()
    {
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("ButtonClose");
    }
}
