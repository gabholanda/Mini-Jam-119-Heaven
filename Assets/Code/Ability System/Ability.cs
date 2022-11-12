using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public List<string> hitableTags;
    public GameObject caster;
    public Vector2 direction;
    public float angle;
    public AbilityData data;
    protected Rigidbody2D rb;
    protected CharacterStats abilityStats;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        abilityStats = GetComponent<CharacterStats>();
    }

    protected void StartDamageProcess(Collider2D collision)
    {
        // TODO: @Brett Do a damage system
        // Instructions: Your abilities that do damage will need something called
        // DamageDealer which is a script that starts the process of dealing damage
        // while the one taking the damage will have something called DamageReceiver
        // which is another script that finishes the damaging process by subtracting the receiver HP
        // Why do this so complicated? Simple, because we want to spawn particles OnHit
        // And with this system we can also implement life stealing and anything related to
        // OnHit or OnTakingHit events
        if (hitableTags.Contains(collision.tag))
        {
            CharacterStats stats = GetStats(collision);
            stats.CurrentHealth -= (int)Mathf.Floor(
                caster.GetComponent<CharacterStats>().Damage
                * data.scalingCoeficient);
            Debug.Log(stats.CurrentHealth);
        }
        else if (collision.CompareTag("Projectile"))
        {
            CharacterStats stats = GetStats(collision);
            if (stats.Damage > abilityStats.Damage)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }

    public virtual void AfterAwake()
    {
        transform.localScale = caster.transform.localScale;
        StartCoroutine(AutoDestroy());
    }

    protected CharacterStats GetStats(Collider2D collision)
    {
        return collision.GetComponent<CharacterStats>();
    }

    private IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(data.autoDestroyTimer);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
