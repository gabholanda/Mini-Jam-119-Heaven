using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void DealDamage(float attackDamage, GameObject defender, Ability ability)
    {
        DamageReceiver receiver = defender.GetComponent<DamageReceiver>();
        if (ability.data.onHitParticle) ability.data.onHitParticle.Play();
        if (ability.data.soundFX && audioSource) {
            audioSource.clip = ability.data.soundFX;
            audioSource.Play();
        }
        int totalDamage = (int)(ability.data.scalingCoeficient * attackDamage);
        receiver.ReceiveDamage(totalDamage);
    }
}
