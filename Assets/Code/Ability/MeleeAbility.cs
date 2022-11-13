using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAbility : Ability
{
    public DamageDealer dealer;
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
