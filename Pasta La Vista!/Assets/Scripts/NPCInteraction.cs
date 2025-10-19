using UnityEngine;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    // Array to hold all the dialogue lines the NPC will say
    public string[] dialogueLines;

    // Reference to the TMP text UI element that will display dialogue
    public TextMeshProUGUI dialogueText;

    // The dialogue panel (UI container) that holds the text
    public GameObject dialoguePanel;

    // Keeps track of which line of dialogue we're currently on
    private int currentLine = 0;

    // Flags to check if the player is near the NPC and if dialogue is active
    private bool playerInRange = false;
    private bool isTalking = false;

    void Update()
    {
        // Check if player is close enough and presses "E"
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isTalking)
            {
                // Start the dialogue if it's not already active
                StartDialogue();
            }
            else
            {
                // Otherwise, go to the next line of dialogue
                NextLine();
            }
        }
    }

    void StartDialogue()
    {
        isTalking = true;                       // NPC is now talking
        dialoguePanel.SetActive(true);          // Show the dialogue UI
        currentLine = 0;                        // Start from the first line
        dialogueText.text = dialogueLines[currentLine];  // Display first line
    }

    void NextLine()
    {
        currentLine++;  // Move to the next line

        if (currentLine < dialogueLines.Length)
        {
            // If we still have lines left, display the next one
            dialogueText.text = dialogueLines[currentLine];
        }
        else
        {
            // Otherwise, end the dialogue
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        isTalking = false;              // NPC is no longer talking
        dialoguePanel.SetActive(false); // Hide the dialogue UI
    }

    // Detect when the player enters the NPC's trigger zone
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;  // Player is close enough to talk
        }
    }

    // Detect when the player leaves the NPC's trigger zone
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;      // Player is too far to interact
            if (isTalking) EndDialogue(); // End dialogue if they walk away mid-convo
        }
    }
}
