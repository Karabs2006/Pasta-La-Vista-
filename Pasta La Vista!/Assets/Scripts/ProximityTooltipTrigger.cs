/* using UnityEngine;
using TMPro; // Essential for TextMeshPro

public class ProximityTooltipTrigger : MonoBehaviour
{
    // The player object (assign Player_Francesco here)
    public Transform playerObject;

    // The UI element to show/hide (assign WorldSpaceTooltipCanvas here)
    public GameObject tooltipPanel;

    // Distance check setting
    public float activationDistance = 3.0f;

    // Content for this specific tooltip
    [TextArea]
    public string hintText = "Press E to Interact.";

    // Internal reference to the actual text component
    private TextMeshProUGUI textComponent;

    void Start()
    {
        // Safety check to ensure references are set before trying to access components
        if (tooltipPanel != null)
        {
            // Get the TextMeshPro component from the children of the panel
            textComponent = tooltipPanel.GetComponentInChildren<TextMeshProUGUI>();

            // Ensure the panel is hidden when the game starts
            tooltipPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Tooltip Panel reference missing on " + gameObject.name);
        }

        if (playerObject == null)
        {
            Debug.LogError("Player Object reference missing on " + gameObject.name);
        }
    }

    void Update()
    {
        // Exit early if essential references are missing
        if (playerObject == null || tooltipPanel == null) return;

        // Calculate the distance
        float distance = Vector3.Distance(transform.position, playerObject.position);

        if (distance <= activationDistance)
        {
            // Player is in range: Show Tooltip
            if (!tooltipPanel.activeSelf)
            {
                // Set the correct text before showing
                if (textComponent != null)
                {
                    textComponent.text = hintText;
                }

                tooltipPanel.SetActive(true);
            }
        }
        else
        {
            // Player is out of range: Hide Tooltip
            if (tooltipPanel.activeSelf)
            {
                tooltipPanel.SetActive(false);
            }
        }
    }
}
*/