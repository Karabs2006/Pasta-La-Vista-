using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [Header("Pause Menu Settings")]
    public GameObject pauseMenu;
    public FPController fPController;
    public Phone phone;

    void Start()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (fPController != null)
        {
            // Handle pause/resume
            if (fPController.pausePressed && !phone.phone.activeSelf)
            {
                if (pauseMenu != null)
                {
                    if (pauseMenu.activeSelf)
                        ResumeGame();
                    else
                        PauseGame();
                }
                else
                {
                    Debug.LogWarning("PauseMenu is not assigned in the Inspector!");
                }

                fPController.pausePressed = false;
            }

            // Handle quit
            if (fPController.quitPressed)
            {
                QuitGame();
                fPController.quitPressed = false;
            }
        }
        else
        {
            Debug.LogWarning("fPController is not assigned in the Inspector!");
        }
    }


    // Pause menu functions
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
