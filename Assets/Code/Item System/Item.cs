using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : PowerUp, IInteractable
{
    public ItemSO data;
    public GameObject playerObj;
    private SpriteRenderer spriteRenderer;
    private TMPro.TextMeshPro textMesh;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = data.sprite;
        textMesh = GetComponentInChildren<TMPro.TextMeshPro>();
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
            textMesh.text = data.description;
            textMesh.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textMesh.enabled = false;
    }
}
