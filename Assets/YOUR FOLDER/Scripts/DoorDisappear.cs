using System.Collections;
using TMPro;
using UnityEngine;

public class DoorDisappear : MonoBehaviour
{
    [SerializeField] private float reappearDelay = 1f;    
    [SerializeField] private float disappearDelay = 1f;   
    [SerializeField] private bool doorNeedsKey = false;   // key
    
    [SerializeField] private bool requiresButtonPress = false; //button
    [SerializeField] private ButtonSwitch linkedButton;        

    private Collider2D solidCollider;    
    private SpriteRenderer doorSprite;   
    
    [SerializeField] private GameObject textGameObject;
    [SerializeField] private TextMeshProUGUI textMeshPro;

    void Start()
    {
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
         
        }

        if (doorSprite == null)
        {
          
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        // check if the button is pressed
        if (requiresButtonPress)
        {
            if (linkedButton == null || !linkedButton.isPressed)
            {
                
                return; 
            }
        }

        // check for key
        if (doorNeedsKey)
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory == null || !playerInventory.hasCoin)
            {

                textGameObject.SetActive(true);
                textMeshPro.text = "You need the coin to open the door";
                
                return; 
            }
        }

        // If no button press or key needed
        StartCoroutine(DelayedDoorDisappear());
    }

    private IEnumerator DelayedDoorDisappear()
    {
        // Wait disappearing
        yield return new WaitForSeconds(disappearDelay);

        if (solidCollider != null) solidCollider.enabled = false;
        if (doorSprite != null) doorSprite.enabled = false;

        // Wait reappearing
        yield return new WaitForSeconds(reappearDelay);

        if (solidCollider != null) solidCollider.enabled = true;
        if (doorSprite != null) doorSprite.enabled = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textGameObject.SetActive(false);
        }
        
    }

}