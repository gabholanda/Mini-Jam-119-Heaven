using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickablePowerUp : MonoBehaviour, IInteractable
{
    public delegate void OnDestroyPowerUpHandler(GameObject g);
    public event OnDestroyPowerUpHandler OnDestroyPowerUpEvent;

    public delegate void OnPickUpPowerUpHandler(GameObject g);
    public event OnPickUpPowerUpHandler OnPickUpPowerUpEvent;

    public GameObject powerUpPrefab;

    private bool canSpawn = true;

    private GameObject playerObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.interactable = gameObject;
            playerObj = collision.gameObject;
        }
    }

    public void Interact()
    {
        Instantiate(powerUpPrefab, playerObj.transform);
        OnPickUpPowerUpEvent?.Invoke(gameObject);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (gameObject != null)
            OnDestroyPowerUpEvent?.Invoke(gameObject);
        if (canSpawn)
        {
            GetComponent<LootBag>().InstantiateLoot(transform.position);
        }
    }

    private void OnApplicationQuit()
    {
        canSpawn = false;
    }
}
