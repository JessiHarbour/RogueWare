using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public GameObject itemPrefab;         
    public GameObject itemTextPrefab;  
    public float textDuration = 2f;      
    public Sprite openedChestSprite;      // The sprite open chest
    public Sprite closedChestSprite;      // The sprite closed chest

    private bool playerInRange = false;   // is player near chest
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        //  closed chest sprite
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = closedChestSprite;
        }
       
    }

    void Update()
    {
        // If the player presses e and is near the chest open it
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void OpenChest()
    {
        // Change to opened chest sprite
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = openedChestSprite;
        }

        // spawn cookie
        if (itemPrefab != null)
        {
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
        
        if (itemTextPrefab != null)
        {
            GameObject itemText = Instantiate(itemTextPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            Destroy(itemText, textDuration);  // Destroy the text after the specified duration
        }
        
    }
}