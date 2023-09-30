using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(player.transform.position, Vector3.up, -rotationSpeed);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(player.transform.position, Vector3.up, rotationSpeed);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation = initialRotation;
        }
    }
}
