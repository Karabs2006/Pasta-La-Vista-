using UnityEngine;
using UnityEngine.SceneManagement;


public class GameEnd : MonoBehaviour
{
    public AudioSource buttonAudio;
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
