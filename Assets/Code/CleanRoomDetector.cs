using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanRoomDetector : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyManager>().OnAllEnemiesDeathEvent += TurnOnCollider;
    }

    public void TurnOnCollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }
}
