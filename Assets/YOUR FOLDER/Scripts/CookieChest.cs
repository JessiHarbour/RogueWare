using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CookieChest : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isChestOpen = false;
    
    [SerializeField] private Sprite chestOpen;
    [SerializeField] GameObject cookie;
    [SerializeField] BoxCollider2D boxCollider;

    [SerializeField] private GameObject textGameObject;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    
    
    

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isChestOpen)
        {
            textGameObject.SetActive(true);
            textMeshPro.text = "Open chest? (E)";
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isChestOpen)
        {
            textGameObject.SetActive(false);
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isChestOpen)
        {
            if (Input.GetKey(KeyCode.E))
            {
                spriteRenderer.sprite = chestOpen;
                isChestOpen = true;
                boxCollider.enabled = false;
                Instantiate(cookie, transform.position + (Vector3.down * .75f), Quaternion.identity);
                textGameObject.SetActive(false);
            }
        }
       
    }
    
    
}
