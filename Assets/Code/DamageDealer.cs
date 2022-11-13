using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public void DealDamage(float attackDamage, GameObject defender, Ability ability)
    {
        DamageReceiver receiver = defender.GetComponent<DamageReceiver>();
        if (ability.data.onHitParticle) ability.data.onHitParticle.Play();
        int totalDamage = (int)(ability.data.scalingCoeficient * attackDamage);
        receiver.ReceiveDamage(totalDamage);
    }
}
