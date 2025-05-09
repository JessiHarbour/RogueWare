using UnityEngine;
using System.Collections;

public class DoorDisappear : MonoBehaviour
{
    [SerializeField] private float reappearDelay = 1f;      // Time disappearing before reappearing
    [SerializeField] private float disappearDelay = 1f;     // Time disappears after interaction

    private Collider2D solidCollider;     // collider for blocking
    private SpriteRenderer doorSprite;

    void Start()
    {
        // Get the solid collider 
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D col in colliders)
        {
            if (!col.isTrigger)
            {
                solidCollider = col;
                break;
            }
        }

        doorSprite = GetComponent<SpriteRenderer>();

        if (solidCollider == null)
        {
            Debug.LogWarning("No solid collider found on the door!");
        }

        if (doorSprite == null)
        {
            Debug.LogWarning("No SpriteRenderer found on the door!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DelayedDoorDisappear());
        }
    }

    private IEnumerator DelayedDoorDisappear()
    {
        // Wait before disappearing
        yield return new WaitForSeconds(disappearDelay);

        if (solidCollider != null) solidCollider.enabled = false;
        if (doorSprite != null) doorSprite.enabled = false;

        // Wait before reappearing
        yield return new WaitForSeconds(reappearDelay);

        if (solidCollider != null) solidCollider.enabled = true;
        if (doorSprite != null) doorSprite.enabled = true;
    }
}