using UnityEngine;
using UnityEngine.InputSystem;

public class CameraTesteMouse : MonoBehaviour
{
    [SerializeField] private float sensibilidade = 0.15f;

    private float horizontal;
    private float vertical;

    private void OnEnable()
    {
        Vector3 angulos = transform.localEulerAngles;
        horizontal = angulos.y;
        vertical = Mathf.DeltaAngle(0f, angulos.x);
    }

    private void Update()
    {
        Mouse mouse = Mouse.current;

        if (mouse == null || !mouse.rightButton.isPressed)
            return;

        Vector2 movimento = mouse.delta.ReadValue() * sensibilidade;

        horizontal = Mathf.Repeat(horizontal + movimento.x, 360f);
        vertical = Mathf.Clamp(vertical - movimento.y, -89f, 89f);

        transform.localRotation = Quaternion.Euler(vertical, horizontal, 0f);
    }
}