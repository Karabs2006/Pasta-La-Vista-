using UnityEngine;
using UnityEngine.SceneManagement;


public class GameEnd : MonoBehaviour
{
    public AudioSource buttonAudio;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Restart()
    {
        buttonAudio.Play();
        SceneManager.LoadSceneAsync("GameScene");
    }
    public void Quit()
    {   
        Application.Quit();
    }
}
