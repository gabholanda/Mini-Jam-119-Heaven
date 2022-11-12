using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;

    private float distance;
    public CharacterStats characterStats;
    void Awake()
    {
      
        characterStats = GetComponent<CharacterStats>();
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        if (distance >= 1)
        {

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, characterStats.Speed * Time.deltaTime);

        }
    }
}
