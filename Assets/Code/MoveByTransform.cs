using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTransform : MonoBehaviour, IMovable
{

    private Vector2 direction;
    public void Move()
    {
        transform.Translate(direction * Time.deltaTime);
    }

    public void SetVector(Vector2 v2)
    {
        direction = v2;
    }


    void Update() 
    {
        Move();
    }

}
