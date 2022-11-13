using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelBeamAbility : Ability
{
    public DamageDealer dealer;
    void Update()
    {
        rb.AddForce(direction * abilityStats.Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hitableTags.Contains(collision.tag))
        {
            if (caster)
                dealer.DealDamage(caster.GetComponent<CharacterStats>().Damage, collision.gameObject, this);
        }
        else if (collision.CompareTag("Projectile"))
        {
            ProjectileCollision(collision);
        }
    }
}
