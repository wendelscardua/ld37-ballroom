using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndThrow : MonoBehaviour {
    public Transform playerHand;
    public float throwForce = 10.0f;
    public float alpha = 0.5f;
    private Transform pickedObject = null;
    private Color originalColor;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1"))
        {
            if (pickedObject == null)
            {
                PickUp();
            }
            else
            {
                ThrowAway();
            }

        }
    }

    private void PickUp()
    {
        var mainCamera = FindCamera();

        // We need to actually hit an object
        RaycastHit hit = new RaycastHit();
        if (
            Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition).origin,
                             mainCamera.ScreenPointToRay(Input.mousePosition).direction, out hit, 100,
                             Physics.DefaultRaycastLayers))
        {
            // We need to hit a rigidbody that is not kinematic
            if (hit.rigidbody && !hit.rigidbody.isKinematic && hit.rigidbody.CompareTag("Ball"))
            {
                pickedObject = hit.rigidbody.transform;
                originalColor = pickedObject.GetComponent<Renderer>().material.color;
                pickedObject.GetComponent<Renderer>().material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
                pickedObject.parent = playerHand;
                pickedObject.transform.position = playerHand.position;
                pickedObject.transform.rotation = playerHand.rotation;
                pickedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    private void ThrowAway()
    {
        pickedObject.GetComponent<Renderer>().material.color = originalColor;
        pickedObject.GetComponent<Rigidbody>().isKinematic = false;
        pickedObject.transform.position = playerHand.position;
        pickedObject.transform.rotation = playerHand.rotation;
        pickedObject.GetComponent<Rigidbody>().AddForce(pickedObject.transform.forward * throwForce, ForceMode.Impulse);
        pickedObject.parent = null;
        pickedObject = null;
    }

    private Camera FindCamera()
    {
        Camera camera = GetComponent<Camera>();
        if (camera != null)
        {
            return camera;
        }

        return Camera.main;
    }
}
