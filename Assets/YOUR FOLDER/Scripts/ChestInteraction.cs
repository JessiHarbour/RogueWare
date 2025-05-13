using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public GameObject itemPrefab;         // The item prefab (cookie) that will appear after the chest opens
    public GameObject itemTextPrefab;     // The prefab for the text that will show up
    public float textDuration = 2f;       // Duration for how long the text will stay on screen
    public Sprite openedChestSprite;      // The sprite for the opened chest
    public Sprite closedChestSprite;      // The sprite for the closed chest

    private bool playerInRange = false;   // To track if the player is near the chest
    private SpriteRenderer spriteRenderer; // To reference the SpriteRenderer of the chest

    void Start()
    {
        // Get the SpriteRenderer component of the chest
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the initial sprite to the closed chest sprite
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = closedChestSprite;
        }
        else
        {
            Debug.LogError("No SpriteRenderer found on the chest.");
        }
    }

    void Update()
    {
        // If the player presses 'E' and is near the chest, open it
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has entered the trigger zone of the chest
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player has exited the trigger zone of the chest
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void OpenChest()
    {
        // Change the chest sprite to the opened chest sprite
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = openedChestSprite;
        }

        // Instantiate the item at the chest's position
        if (itemPrefab != null)
        {
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
        
        if (itemTextPrefab != null)
        {
            GameObject itemText = Instantiate(itemTextPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            Destroy(itemText, textDuration);  // Destroy the text after the specified duration
        }

        // Destroy the chest or make it inactive
        Destroy(gameObject); 
    }
}