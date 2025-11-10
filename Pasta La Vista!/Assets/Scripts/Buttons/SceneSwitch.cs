using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // Scene loading functions
    public void PlayIntroductionScene01()
    {
        SceneManager.LoadSceneAsync("IntroductionScene01");
    }

    public void PlayIntroductionScene02()
    {
        SceneManager.LoadSceneAsync("IntroductionScene02");
    }

    public void PlayTutScene()
    {
        SceneManager.LoadSceneAsync("TutorialScene");
    }
}
