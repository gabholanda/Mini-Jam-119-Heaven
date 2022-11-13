using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

    public AbilityTrigger meleeAttack;
    private AbilityTrigger realMeleeAttack;


    public GameObject interactable;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        movable = GetComponent<IMovable>();
        characterStats = GetComponent<CharacterStats>();
        realMeleeAttack = ScriptableObject.CreateInstance<AbilityTrigger>();
        realMeleeAttack.DeepCopy(meleeAttack);
        realMeleeAttack.Initialize(gameObject);
    }

    private void OnEnable()
    {
        reader.Attack.performed += OnAttack;
        reader.Dash.performed += OnDash;
        reader.Move.performed += OnMove;
        reader.Move.canceled += OnStopMove;
        reader.Interact.performed += OnInteract;
        reader.Interact.Enable();
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
        reader.Interact.performed -= OnInteract;
        reader.Interact.Disable();
        reader.Move.Disable();
        reader.Attack.Disable();
        reader.Dash.Disable();
    }

    private void OnInteract(InputAction.CallbackContext obj)
    {
        if (interactable != null)
        {
            interactable.GetComponent<IInteractable>()?.Interact();
        }
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
        realMeleeAttack.Fire(point.position, MouseUtils.GetMousePositionInWorld());
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        transform.position = new Vector3();
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

    private void OnDestroy()
    {
        SceneManager.LoadScene("Floor1-Room1");
    }
}

