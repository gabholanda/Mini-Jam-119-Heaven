using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : PowerUp, IInteractable
{
    public ItemSO data;
    public GameObject playerObj;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = data.sprite;
    }

    public void Interact()
    {
        OnEquip(playerObj);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.interactable = gameObject;
            playerObj = collision.gameObject;
        }
    }
}
