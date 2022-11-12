using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputReader reader;
    public Transform point;
    public float radius = 1;
    public IMovable movable;

    public Vector2 direction;
    public float dashCooldown;
    public float dashDuration;
    private bool canDash = true;


    public CharacterStats characterStats;
    
    void Awake()
    {
        movable = GetComponent<IMovable>();
        characterStats = GetComponent<CharacterStats>();
    }

    private void OnEnable()
    {
        reader.Attack.performed += OnAttack;
        reader.Dash.performed += OnDash;
        reader.Move.performed += OnMove;
        reader.Move.canceled += OnStopMove;
        reader.Move.Enable();
        reader.Attack.Enable();
        reader.Dash.Enable();
    }


    private void OnDisable()
    {
        reader.Move.performed -= OnMove;
        reader.Attack.performed -= OnAttack;
        reader.Move.canceled -= OnStopMove;
        reader.Dash.performed -= OnDash;
        reader.Move.Disable();
        reader.Attack.Disable();
        reader.Dash.Disable();
    }

    private void OnDash(InputAction.CallbackContext context)
    {
        if (canDash)
        {
            canDash = false;
            movable.SetVector(direction * 10);
            StartCoroutine(CoolDown());
            StartCoroutine(DashingDuration());
        }



    }

    private void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        movable.SetVector(direction);
    }
    private void OnStopMove(InputAction.CallbackContext context)
    {
        movable.SetVector(new Vector2(0, 0));
    }
    private void OnAttack(InputAction.CallbackContext context)
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(point.position, radius);
        for (int i = 0; i < enemies.Length; i++)
        {
            Debug.Log(enemies[i].name);
            enemies[i].GetComponent<CharacterStats>().CurrentHealth -= characterStats.Damage;
            Debug.Log(enemies[i].GetComponent<CharacterStats>().CurrentHealth);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(point.position, radius);
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    IEnumerator DashingDuration()
    {
        yield return new WaitForSeconds(dashDuration);
        movable.SetVector(direction);
    }

}

