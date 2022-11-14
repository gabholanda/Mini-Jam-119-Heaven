using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{
    public PowerUpStats powerUpStats;
    public UnityEvent OnEquipEvent;

    private void Awake()
    {
        OnEquip();
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
            playerStats.Damage = (int)(playerStats.Damage * (powerUpStats.damage / 100 + 1.0f));
        }

        if (powerUpStats.isHealthFlat)
        {
            playerStats.MaxHealth += (int)powerUpStats.health;
        }
        else
        {
            playerStats.MaxHealth = (int)(playerStats.MaxHealth * (powerUpStats.health / 100 + 1.0f));
        }

        if (powerUpStats.isSpeedFlat)
        {
            playerStats.Speed += powerUpStats.speed;
        }
        else
        {
            playerStats.Speed *= (powerUpStats.speed / 100 + 1.0f);
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
            playerStats.Damage = (int)(playerStats.Damage * (powerUpStats.damage / 100 + 1.0f));
        }

        if (powerUpStats.isHealthFlat)
        {
            playerStats.MaxHealth += (int)powerUpStats.health;
        }
        else
        {
            playerStats.MaxHealth = (int)(playerStats.MaxHealth * (powerUpStats.health / 100 + 1.0f));
        }

        if (powerUpStats.isSpeedFlat)
        {
            playerStats.Speed += powerUpStats.speed;
        }
        else
        {
            playerStats.Speed *= (powerUpStats.speed / 100 + 1.0f);
        }
        OnEquipEvent?.Invoke();
    }
}
