using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("GameScene"); //Loads game
    }
}
