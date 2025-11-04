using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LoadingScreen : MonoBehaviour
{
    public GameObject DotTwo;
    public GameObject DotThree;
    bool loading = true;
    void Start()
    {
        DotTwo.SetActive(false);
        DotThree.SetActive(false);
        StartCoroutine(Stars());
        StartCoroutine(LoadGame());
    }

    IEnumerator Stars()
    {
        while (loading)
        {   
            yield return new WaitForSeconds(0.8f);
            DotTwo.SetActive(true);

            yield return new WaitForSeconds(0.8f);
            DotThree.SetActive(true);

            yield return new WaitForSeconds(0.8f);
            DotTwo.SetActive(false);
            DotThree.SetActive(false);
        }

    }
    
    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadSceneAsync("GameScene");
        
    }
}
