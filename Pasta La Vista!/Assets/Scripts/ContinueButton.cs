using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("IntroductionScene"); //Loads game
    }
}
