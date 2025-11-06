/*Title: How to Make an Object Move Towards Another Object in Unity
Author: Brackeys
Date Accessed: 25 October 2025
Code Version: Unity 2020+ Compatible
Availability: https://www.youtube.com/watch?v=rhoQd6IAtDo

Title: Unity Tutorial -Waypoint System for AI Movement
Author: SpeedTutor
Date Accessed: 25 October 2025
Code Version: Unity 2019+ Compatible
Availability: https://www.youtube.com/watch?v=U6H7U0R2mh0
*/
using UnityEngine;

public class ScooterMovement : MonoBehaviour
{
    private Transform landPoint;
    public float flySpeed = 10f;

    private bool hasLanded = false;
    private ScooterConveyorMovement conveyorMovement;

    public void SetLandPoint(Transform point)
    {
        landPoint = point;
    }

    void Start()
    {
        
        conveyorMovement = GetComponent<ScooterConveyorMovement>();
    }

    void Update()
    {
        if (!hasLanded && landPoint != null)
        {
            // Flying to land point
            transform.position = Vector3.MoveTowards(transform.position, landPoint.position, flySpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, landPoint.position) < 0.1f)
            {
                hasLanded = true;
                OnLanded();
            }
        }
    }

    void OnLanded()
    {


        // Start the conveyor movement
        if (conveyorMovement != null)
        {
            conveyorMovement.StartConveyorMovement();
        }
    }
}
