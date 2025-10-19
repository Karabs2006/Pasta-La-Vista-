using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void PlayGameScene()
    {
        SceneManager.LoadSceneAsync("GameScene");
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    


}
