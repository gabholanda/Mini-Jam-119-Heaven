using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PowerUp Stat", menuName = "Scriptable Objects/PowerUp System/PowerUp Stat")]
public class PowerUpStats : ScriptableObject
{
    public float damage;
    public float speed;
    public float health;
    public bool isDamageFlat = true;
    public bool isHealthFlat = true;
    public bool isSpeedFlat = true;
}
