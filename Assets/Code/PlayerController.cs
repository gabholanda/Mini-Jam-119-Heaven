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
    
    void Awake()
    {
        movable = GetComponent<IMovable>();
    }
    
    private void OnEnable()
    {
        reader.Move.performed += OnMove;
        reader.Attack.performed += OnAttack;
        reader.Move.Enable();
        reader.Attack.Enable();
    }

    private void OnDisable()
    {
        reader.Move.performed -= OnMove;
        reader.Attack.performed -= OnAttack;
        reader.Move.Disable();
        reader.Attack.Disable();
    }


    private void OnMove(InputAction.CallbackContext context)
    {
        movable.SetVector(context.ReadValue<Vector2>());
        Debug.Log(context.ReadValue<Vector2>());
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
       Collider2D[] enemies = Physics2D.OverlapCircleAll(point.position, radius);
        for (int i = 0; i < enemies.Length; i++)
        {
            // TODO: attack our enemies witin the range
        }
        Debug.Log("I am attacking :)");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(point.position, radius);
    }
}
