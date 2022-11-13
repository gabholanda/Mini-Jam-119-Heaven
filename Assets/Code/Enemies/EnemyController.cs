using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyController : MonoBehaviour
{
    public GameObject player;

    private float distance;
    public CharacterStats characterStats;
    [SerializeField]
    ParticleSystem hitParticle = null;
    [SerializeField]
    private AbilityTrigger trigger;
    protected AbilityTrigger realTrigger;

    protected void Awake()
    {
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
    public void Hit()
    {
        hitParticle.Play();
    }
}
