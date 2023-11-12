using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    public float rotationSpeed = 5.0f;

    private Quaternion initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current == null) return;

        if (Gamepad.current.rightStick.ReadValue().x <= 0 || Input.GetKeyDown(KeyCode.Q))
        {
            transform.RotateAround(player.transform.position, Vector3.up, -rotationSpeed);
        }

        if (Gamepad.current.rightStick.ReadValue().x >= 0 || Input.GetKeyDown(KeyCode.E))
        {
            transform.RotateAround(player.transform.position, Vector3.up, rotationSpeed);
        }

        if (Gamepad.current.buttonNorth.wasReleasedThisFrame)
        {
            transform.rotation = initialRotation;
        }
    }
}
