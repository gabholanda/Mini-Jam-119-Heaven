using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public void DealDamage(GameObject attacker, GameObject defender, Ability ability)
    {
        DamageReceiver receiver = defender.GetComponent<DamageReceiver>();
        if (ability.data.onHitParticle) ability.data.onHitParticle.Play();
        int totalDamage = (int)(ability.data.scalingCoeficient * attacker.GetComponent<CharacterStats>().Damage);
        receiver.ReceiveDamage(totalDamage);
    }
}
