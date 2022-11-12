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
        StartDamageProcess(collision);
    }

}
