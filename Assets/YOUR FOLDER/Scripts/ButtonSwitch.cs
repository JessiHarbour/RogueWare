using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public Sprite buttonUpSprite, buttonDownSprite;

    public bool isPressed = false;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_spriteRenderer != null && buttonUpSprite != null)
        {
            _spriteRenderer.sprite = buttonUpSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !isPressed)
        {
            isPressed = true;

            if (_spriteRenderer != null && buttonDownSprite != null)
            {
                _spriteRenderer.sprite = buttonDownSprite;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // Change sprite back to unpressed  but keep isPressed true
            if (_spriteRenderer != null && buttonUpSprite != null)
            {
                _spriteRenderer.sprite = buttonUpSprite;
            }
        }
    }
}