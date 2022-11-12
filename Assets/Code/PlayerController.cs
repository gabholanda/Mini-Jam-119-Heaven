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
    public CharacterStats characterStats;
    
    void Awake()
    {
        movable = GetComponent<IMovable>();
        characterStats = GetComponent<CharacterStats>();
    }
    
    private void OnEnable()
    {
        reader.Move.performed += OnMove;
        reader.Move.canceled += OnStopMove;
        reader.Attack.performed += OnAttack;
        reader.Move.Enable();
        reader.Attack.Enable();
    }

    private void OnDisable()
    {
        reader.Move.performed -= OnMove;
        reader.Attack.performed -= OnAttack;
        reader.Move.canceled -= OnStopMove;
        reader.Move.Disable();
        reader.Attack.Disable();
    }


    private void OnMove(InputAction.CallbackContext context)
    {
        movable.SetVector(context.ReadValue<Vector2>());
        Debug.Log(context.ReadValue<Vector2>());
    }
    private void OnStopMove(InputAction.CallbackContext context)
    {
        movable.SetVector(new Vector2(0, 0));
        Debug.Log(context.ReadValue<Vector2>());
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
}
