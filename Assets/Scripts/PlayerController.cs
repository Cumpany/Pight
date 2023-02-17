using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public bool HasKey = false;
    [SerializeField] public bool HasUvFlashlight = false;

    public float Speed = 1f;
    public float JumpForce = 5f;
    public float JumpRaycastDistance = 1.1f;

    float mouseX;
    float mouseY;

    public bool canMove = true;

    public List<AudioClip> AudioClips = new List<AudioClip>();
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

        if (canMove)
        {
            movement = transform.TransformDirection(movement);
            GetComponent<Rigidbody>().velocity = movement;
        }

        //movement = transform.TransformDirection(movement);
        //GetComponent<Rigidbody>().velocity = movement;
    }
    void Update()
    {
        if (canMove)
        {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
        }
        // camera movement
        //float mouseX = Input.GetAxis("Mouse X");
        //float mouseY = Input.GetAxis("Mouse Y");

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

        //if player is moving 
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            //if player is not already playing the walking sound
            if (!GetComponent<AudioSource>().isPlaying)
            {
                //play random walking sound
                GetComponent<AudioSource>().clip = AudioClips[Random.Range(0, AudioClips.Count)];
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            //if player is playing the walking sound
            if (GetComponent<AudioSource>().isPlaying)
            {
                //stop the walking sound
                GetComponent<AudioSource>().Stop();
            }
        }
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
