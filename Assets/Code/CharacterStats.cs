using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private int currentHealth;
    public int CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }

    [Min(1)]
    [SerializeField]
    private int maxHealth;
    public int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }

    [Min(0)]
    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } set { damage = value; } }

    [Min(0)]
    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }
}
