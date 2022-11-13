using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public List<string> hitableTags;
    public GameObject caster;
    public Vector2 direction;
    public AbilityData data;
    protected Rigidbody2D rb;
    protected CharacterStats abilityStats;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        abilityStats = GetComponent<CharacterStats>();
    }

    protected void ProjectileCollision(Collider2D collision)
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
