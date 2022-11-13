using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(SceneLoader), typeof(CleanRoomDetector))]
public class EnemyManager : MonoBehaviour
{
    public delegate void OnAllEnemiesDeathHandler();
    public event OnAllEnemiesDeathHandler OnAllEnemiesDeathEvent;
    public List<GameObject> enemies;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] enemiesArr = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemiesArr.Length; i++)
        {
            enemies.Add(enemiesArr[i]);
            enemies[i].GetComponent<CharacterStats>().OnDeathEvent += OnEnemyDeath;
        }
    }

    private void OnEnemyDeath()
    {
        enemies.RemoveRange(0, 1);
        if (enemies.Count == 0)
        {
            OnAllEnemiesDeathEvent?.Invoke();
        }
    }
}
