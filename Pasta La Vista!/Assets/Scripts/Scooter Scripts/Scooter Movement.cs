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
        // Get the conveyor movement component
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
