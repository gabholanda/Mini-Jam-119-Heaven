using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbAbility : Ability
{
    void Update()
    {
        rb.AddForce(direction * abilityStats.Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hitableTags.Contains(collision.tag))
        {
            CharacterStats stats = GetStats(collision);
            stats.CurrentHealth -= (int)Mathf.Floor(
                caster.GetComponent<CharacterStats>().Damage
                * data.scalingCoeficient);
        }
        else if (collision.CompareTag("Projectile"))
        {
            CharacterStats stats = GetStats(collision);
            if (stats.Damage > abilityStats.Damage)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }

}
