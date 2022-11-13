using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{
    public Animator animator;
    public Vector2 position;
    public PowerUpStats powerUpStats;
    public UnityEvent OnEquipEvent;

    private void Awake()
    {
        OnEquip();
        transform.localPosition = position;
    }

    public void OnEquip()
    {
        CharacterStats playerStats = GetComponentInParent<CharacterStats>();

        if (powerUpStats.isDamageFlat)
        {
            playerStats.Damage += (int)powerUpStats.damage;
        }
        else
        {
            float newDamage = playerStats.Damage * (powerUpStats.damage + 1.0f);
            playerStats.Damage *= (int)newDamage;
        }
        if (powerUpStats.isHealthFlat)
        {
            float newHealth = playerStats.Damage * (powerUpStats.damage + 1.0f);
            playerStats.MaxHealth *= (int)newHealth;
        }
        if (powerUpStats.isSpeedFlat)
        {
            float newSpeed = playerStats.Damage * (powerUpStats.damage + 1.0f);
            playerStats.Speed *= newSpeed;
        }
        OnEquipEvent?.Invoke();
    }
    public void OnEquip(GameObject target)
    {
        CharacterStats playerStats = target.GetComponent<CharacterStats>();

        if (powerUpStats.isDamageFlat)
        {
            playerStats.Damage += (int)powerUpStats.damage;
        }
        else
        {
            float newDamage = playerStats.Damage * (powerUpStats.damage + 1.0f);
            playerStats.Damage *= (int)newDamage;
        }
        if (powerUpStats.isHealthFlat)
        {
            playerStats.MaxHealth += (int)powerUpStats.health;
        }
        else
        {
            float newHealth = playerStats.Damage * (powerUpStats.damage + 1.0f);
            playerStats.MaxHealth *= (int)newHealth;
        }
        if (powerUpStats.isSpeedFlat)
        {
            playerStats.Speed += powerUpStats.speed;
        }
        else
        {
            float newSpeed = playerStats.Damage * (powerUpStats.damage + 1.0f);
            playerStats.Speed *= newSpeed;
        }
        OnEquipEvent?.Invoke();
    }

    protected void OnDestroy()
    {
        // TODO: Give the amount of angel feathers to the player
    }
}
