using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyController : MonoBehaviour
{
    protected GameObject player;

    private float distance;
    public CharacterStats characterStats;
    [SerializeField]
    private AbilityTrigger trigger;
    protected AbilityTrigger realTrigger;

    protected virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterStats = GetComponent<CharacterStats>();
        realTrigger = ScriptableObject.CreateInstance<AbilityTrigger>();
        realTrigger.DeepCopy(trigger);
        realTrigger.Initialize(gameObject);
    }

    void Update()
    {
        if (player)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();

            if (distance >= 1)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, characterStats.Speed * Time.deltaTime);
            }

            if (distance <= 1)
            {
                OnAttack();
            }
        }
    }
    private void OnAttack()
    {
        realTrigger.Fire(player.transform.position, new Vector2(0, 0));
    }

    protected void OnDestroy()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        Debug.Log("123");

    }

}

