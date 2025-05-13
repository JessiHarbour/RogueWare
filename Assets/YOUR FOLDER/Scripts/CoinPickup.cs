using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
            //  chec k inventory 
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            
            if (inventory != null)
            {
                // Set the hasCoin to true
                inventory.hasCoin = true;
                
                Destroy(gameObject);
            }
        }
    }
}