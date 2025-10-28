using UnityEngine;

public class ButtonsTutorial : MonoBehaviour
{
    public FPController fPController;
   
    void Start()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fPController.lookSensitivity = 0f;
        
    }

   
    void Update()
    {
        
    }
}
