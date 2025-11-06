/*
Title: Play VIDEO in Unity – Easy Tutorial
Author: Solo Game Dev
Date accessed: 6 November 2025
Code version: Unity VideoPlayer basic setup script
Availability: https://www.youtube.com/watch?v=-XzVq7qIuys

Title: Unity Loading Screen | Beginner Tutorial
Author: Zenva(YouTube Channel)
Date accessed: 6 November 2025
Code version: Scene transition logic (Video end triggers next scene)
Availability: https://www.youtube.com/watch?v=NyFYNsC3H8k
*/

using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class VideoLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;

    void Start()
    {
        // When the video finishes, run the function below
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Load the next scene when the video finishes
        SceneManager.LoadScene(nextSceneName);
    }
}
