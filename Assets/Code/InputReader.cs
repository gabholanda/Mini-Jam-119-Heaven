using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[CreateAssetMenu(fileName = "New Input Reader", menuName = "Scriptable Objects/Input Reader")]
public class InputReader : ScriptableObject
{
    public InputAction Move;
    public InputAction Attack;
    public InputAction Dash;
    public InputAction Interact;
}
