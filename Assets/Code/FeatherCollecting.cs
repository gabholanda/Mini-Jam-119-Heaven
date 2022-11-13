using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherCollecting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.GetComponent<PlayerController>().currency += 1;
            Destroy(gameObject);    
        }


    }
}
