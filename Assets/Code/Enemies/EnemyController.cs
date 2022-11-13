using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyController : MonoBehaviour
{
    public GameObject player;

    private float distance;
    public CharacterStats characterStats;
    public Transform point;
    public float radius = 1;
    [SerializeField] ParticleSystem hitParticle = null;
    void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        if (distance >= 1)
        {

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, characterStats.Speed * Time.deltaTime);
            OnAttack();

        }
    }
    private void OnAttack()
    {
        Collider2D[] Player = Physics2D.OverlapCircleAll(point.position, radius);
        for (int i = 0; i < Player.Length; i++)
        {
            Player[i].GetComponent<CharacterStats>().CurrentHealth -= characterStats.Damage;
            Debug.Log(player.GetComponent<CharacterStats>().CurrentHealth);
            Hit();
        }
    }
    public void Hit()
    {
        hitParticle.Play();
    }
}
