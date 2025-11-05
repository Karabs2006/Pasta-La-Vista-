using UnityEngine;

public class StartWork : MonoBehaviour
{
    public bool inZone = false;
    
    void Update()
    {
        if(inZone)
        {
            Destroy(gameObject);
        }
    }
    
     void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.name == "Player_Francesco")
        {
            inZone = true;
        }
    }
}
