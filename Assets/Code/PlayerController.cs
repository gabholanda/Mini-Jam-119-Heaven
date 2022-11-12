using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputReader reader;
    public Transform point;
    public IMovable movable;

    [Header("Movement")]
    public Vector2 direction;
    public float dashCooldown;
    public float dashDuration;
    private bool canDash = true;
    public float dashSpeed;

    [Header("Stats & Skills")]
    public CharacterStats characterStats;
    [SerializeField]
    ParticleSystem hitParticle = null;

    public AbilityTrigger meleeAttack;


    void Awake()
    {
        movable = GetComponent<IMovable>();
        characterStats = GetComponent<CharacterStats>();
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
        if (Mathf.Abs(direction.x) == 1f || Mathf.Abs(direction.y) == 1f)
        {
            point.localPosition = direction;
        }
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

