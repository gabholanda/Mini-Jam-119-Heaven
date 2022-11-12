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
    public float dashSpeed;

    public CharacterStats characterStats;
    
    [SerializeField]
    ParticleSystem hitParticle = null;

    public AbilityTrigger meleeAttack;


    void Awake()
    {
        movable = GetComponent<IMovable>();
        characterStats = GetComponent<CharacterStats>();
        // The real purpose of a Scriptable Object it is to act as Data Containers
        // meaning they are a single source of truth which replaces the Singleton Pattern
        // You guys will learn this when studying about Design Patterns
        meleeAttack.Initialize(gameObject);
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
        if (canDash && direction.magnitude != 0)
        {
            canDash = false;
            movable.SetVector(characterStats.Speed * dashSpeed * direction);
            StartCoroutine(CoolDown());
            StartCoroutine(DashingDuration());
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        movable.SetVector(direction * characterStats.Speed);
    }
    private void OnStopMove(InputAction.CallbackContext context)
    {
        direction = new Vector2(0, 0);
        movable.SetVector(direction * characterStats.Speed);

    }
    private void OnAttack(InputAction.CallbackContext context)
    {
        meleeAttack.Fire(point.position, MouseUtils.GetMousePositionInWorld());
    }

    public void Hit()
    {
        hitParticle.Play();

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
        movable.SetVector(direction * characterStats.Speed);
    }

}

