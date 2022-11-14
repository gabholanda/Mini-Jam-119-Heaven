using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : PowerUp, IInteractable
{
    public ItemSO data;
    public GameObject playerObj;
    private SpriteRenderer spriteRenderer;
    private TMPro.TextMeshPro textMesh;
    public AudioSource source;

    private void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = data.sprite;
        textMesh = GetComponentInChildren<TMPro.TextMeshPro>();

    }

    public void Interact()
    {
        PlayerController controller = playerObj.GetComponent<PlayerController>();
        if (controller.currency >= data.price)
        {
            controller.currency -= data.price;
            OnEquip(playerObj);
            source.Play();
            Destroy(gameObject);
        }
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
