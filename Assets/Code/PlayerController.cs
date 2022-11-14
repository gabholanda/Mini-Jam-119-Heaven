using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int currency;

    public InputReader reader;
    public Transform point;
    public IMovable movable;

    [Header("Movement")]
    public Vector2 direction;
    public float dashCooldown;
    public float dashDuration;
    private bool canDash = true;
    public float dashSpeed;
    public AudioSource source1;
    public AudioSource source2;

    public AudioClip clip1;
    public AudioClip clip2;

    [Header("Stats & Skills")]
    public CharacterStats characterStats;

    public AbilityTrigger meleeAttack;
    private AbilityTrigger realMeleeAttack;
    public ParticleSystem dashParticle;
    

    public GameObject axe;
    private Animator axeAnim;
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

        axeAnim = axe.GetComponent<Animator>();
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

            source1.PlayOneShot(clip1);
            dashParticle.Play();
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        movable.SetVector(direction * characterStats.Speed);
        if (Mathf.Abs(direction.x) == 1f || Mathf.Abs(direction.y) == 1f)
        {
            point.localPosition = direction * 1.3f;
            if (point.localPosition.x == 1.3f)
            {
                axe.transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            else if (point.localPosition.x == -1.3f)
            {
                axe.transform.localRotation = Quaternion.Euler(0, 0, -90);
            }
            if (point.localPosition.y == 1.3f)
            {
                axe.transform.localRotation = Quaternion.Euler(0, 0, 180);
            }
            if (point.localPosition.y == -1.3f)
            {
                axe.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
    private void OnStopMove(InputAction.CallbackContext context)
    {
        direction = new Vector2(0, 0);
        movable.SetVector(direction * characterStats.Speed);
    }
    private void OnAttack(InputAction.CallbackContext context)
    {
        if (!realMeleeAttack.data.isCoolingDown)
        {
            axeAnim.Play("Swing");
            realMeleeAttack.Fire(point.position, MouseUtils.GetMousePositionInWorld());
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (gameObject)
            transform.position = new Vector3(0, -1);
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
        source2.PlayOneShot(clip2);
        SceneManager.LoadScene("Hub");
    }
}

