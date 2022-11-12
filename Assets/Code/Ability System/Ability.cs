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

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        abilityStats = GetComponent<CharacterStats>();
    }

    protected CharacterStats GetStats(Collider2D collision)
    {
        return collision.GetComponent<CharacterStats>();
    }

}
