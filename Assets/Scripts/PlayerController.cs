using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]public bool HasKey = false;

    public float Speed = 1f;
    public float JumpForce = 5f;
    public float JumpRaycastDistance = 1.1f;
    void FixedUpdate()
    {
        // normal movement
        float RunMultiplier = 1f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            RunMultiplier = 2f;
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical).magnitude > 1
        ? new Vector3(horizontal, 0, vertical).normalized : new Vector3(horizontal, 0, vertical);
        movement *= Speed * RunMultiplier;
        movement = new Vector3(movement.x, GetComponent<Rigidbody>().velocity.y, movement.z);

        movement = transform.TransformDirection(movement);
        GetComponent<Rigidbody>().velocity = movement;
    }
    void Update()
    {

        // camera movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(0, mouseX, 0);

        Camera.main.transform.Rotate(-mouseY, 0, 0);
        // clamp camera rotation to prevent flipping
        float cameraRotation = Camera.main.transform.localEulerAngles.x;
        if (cameraRotation > 180)
        {
            cameraRotation -= 360;
        }
        cameraRotation = Mathf.Clamp(cameraRotation, -90, 90);
        Camera.main.transform.localEulerAngles = new Vector3(cameraRotation, 0, 0);
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
