using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public delegate void OnDeathHandler();
    public event OnDeathHandler OnDeathEvent;

    private int currentHealth;
    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            if (value <= 0)
            {
                OnDeathEvent?.Invoke();
                Destroy(gameObject);
            }

            currentHealth = value;
        }
    }

    [Min(1)]
    [SerializeField]
    private int maxHealth;
    public int MaxHealth { get { return maxHealth; } set { maxHealth = value; CurrentHealth = value; } }

    [Min(0)]
    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } set { damage = value; } }

    [Min(0)]
    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }
}
