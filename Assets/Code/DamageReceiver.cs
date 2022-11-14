using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    CharacterStats characterStats;
    public ParticleSystem onHitted;
    public AudioSource source;
    public AudioClip clip;
    private void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
    }
    public void ReceiveDamage(int totalDamage)
    {

        characterStats.CurrentHealth -= totalDamage;
        if (onHitted) {
            onHitted.Play();
        }
         if (source && clip) source.PlayOneShot(clip);
    }
}
