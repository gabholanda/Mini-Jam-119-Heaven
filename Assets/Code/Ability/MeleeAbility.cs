using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAbility : Ability
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartDamageProcess(collision);
    }
}
