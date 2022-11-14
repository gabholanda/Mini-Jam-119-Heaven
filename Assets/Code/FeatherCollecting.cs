using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherCollecting : MonoBehaviour
{
    public AudioSource source;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().currency += 1;
            source.Play();
            Destroy(gameObject);
        }


    }
}
