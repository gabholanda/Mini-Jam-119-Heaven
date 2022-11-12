using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByRigidBody : MonoBehaviour, IMovable
{
    private Rigidbody2D rb;
    private Vector2 direction;
    public void Move()
    {
        rb.AddForce(direction);
    }

    public void SetVector(Vector2 v2)
    {
        direction = v2;
    }

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
}
