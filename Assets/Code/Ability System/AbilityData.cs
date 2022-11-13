using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability Data", menuName = "Scriptable Objects/Ability System/Ability Data")]
public class AbilityData : ScriptableObject
{
    [Header("Art Effects")]
    [ColorUsage(true, true)]
    public Color color;
    public AudioClip soundFX;
    public ParticleSystem onHitParticle;
    public ParticleSystem onCastParticle;

    [Header("Battle Data")]
    [Min(0.01f)]
    public float scalingCoeficient = 1.0f;
    [Min(0)]
    public float autoDestroyTimer = 1.0f;
    public bool isProjectile = false;
    public bool isBoundToCaster = false;
    public bool isInSetPosition = false;

    [Header("Cooldown Data")]
    public bool isCoolingDown = false;
    public float cooldownDuration = 0f;

    public void DeepCopy(AbilityData otherData)
    {
        color = otherData.color;
        soundFX = otherData.soundFX;
        onHitParticle = otherData.onHitParticle;
        onCastParticle = otherData.onCastParticle;
        scalingCoeficient = otherData.scalingCoeficient;
        autoDestroyTimer = otherData.autoDestroyTimer;
        isProjectile = otherData.isProjectile;
        isBoundToCaster = otherData.isBoundToCaster;
        isInSetPosition = otherData.isInSetPosition;
        isCoolingDown = otherData.isCoolingDown;
        cooldownDuration = otherData.cooldownDuration;
    }
}
