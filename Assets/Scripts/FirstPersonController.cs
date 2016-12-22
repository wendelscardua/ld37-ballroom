using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]

public class FirstPersonController : MonoBehaviour {
    public float speedFactor = 10.0f;
    public float mouseSensitivity = 10.0f;
    public float upDownRange = 60.0f;
    public float jumpSpeed = 20.0f;
    public float pushPower = 2.0f;
    float verticalRotation = 0.0f;
    float verticalVelocity = 0.0f;
    CharacterController characterController;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
        }

        // Look
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        float rotUpDown = Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation -= rotUpDown;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Movement
        float forwardSpeed = Input.GetAxis("Vertical") * speedFactor;
        float sideSpeed = Input.GetAxis("Horizontal") * speedFactor;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded) {
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpSpeed;
            }
            else
            {
                verticalVelocity = 0.0f;
            }
        }

        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
        characterController.Move(transform.rotation * speed * Time.deltaTime);
	}

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3F)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;
    }
}
