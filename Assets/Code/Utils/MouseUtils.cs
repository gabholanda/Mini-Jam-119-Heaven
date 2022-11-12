using UnityEngine;
using UnityEngine.InputSystem;

public static class MouseUtils
{
    public static Vector2 GetMousePositionInWorld()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        return worldPos;
    }
}
