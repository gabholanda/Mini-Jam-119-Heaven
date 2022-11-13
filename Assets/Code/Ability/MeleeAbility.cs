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
            dealer.DealDamage(caster, collision.gameObject, this);
        }
        else if (collision.CompareTag("Projectile"))
        {
            ProjectileCollision(collision);
        }
    }
}
