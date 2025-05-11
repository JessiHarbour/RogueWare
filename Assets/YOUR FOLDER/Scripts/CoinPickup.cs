using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
            // Get the Inventory 
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            
            if (inventory != null)
            {
                // Set the hasCoin to true when the player picks up the coin
                inventory.hasCoin = true;
                
                Destroy(gameObject);
            }
        }
    }
}