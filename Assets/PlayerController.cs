using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 1f;
    public float JumpForce = 5f;
    public float JumpRaycastDistance = 1.1f;
    void FixedUpdate()
    {
        // normal movement
        float horizontal = Input.GetAxis("Horizontal") * Speed;
        float vertical = Input.GetAxis("Vertical") * Speed;
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        transform.Translate(movement);
    }
    void Update()
    {

        // camera movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(0, mouseX, 0);
        Camera.main.transform.Rotate(-mouseY, 0, 0);
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
