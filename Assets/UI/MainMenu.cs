using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        OptionsControls.inMenu = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void PlayGame()
    {
        OptionsControls.inMenu = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("Level 1");
    }

    public void L1()
    {
        OptionsControls.inMenu = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("Level 1");
    }
    public void L2()
    {
        OptionsControls.inMenu = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("Level 2");
    }
    public void L3()
    {
        OptionsControls.inMenu = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("Level 3");
    }
    public void L4()
    {
        OptionsControls.inMenu = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("Level 4");
    }
    public void L5()
    {
        OptionsControls.inMenu = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("Level 4.5");
    }
    public void L6()
    {
        OptionsControls.inMenu = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("Level 5");
    }
    public void QuitGame()
    {
        Debug.Log("You quit!");
        Application.Quit();
    }
}
