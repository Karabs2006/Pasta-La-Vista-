using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject pauseMenu;
    public FPController fPController;

    void Start()
    {
        pauseMenu.SetActive(false); 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (fPController.pausePressed)
        {
            if (pauseMenu.activeSelf)
            {
                ResumeGame();
                fPController.pausePressed = false;
            }
            else
            {
                PauseGame();
                fPController.pausePressed = false;
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fPController.lookSensitivity = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fPController.lookSensitivity = 2f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
