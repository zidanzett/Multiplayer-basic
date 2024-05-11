using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [Range(1f, 10f)]
    public float movementSpeed = 7f;

    private Rigidbody rigidBody;

    private float horizontalInput, verticalInput;

    private void Start() {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal") * movementSpeed;
        verticalInput = Input.GetAxis("Vertical") * movementSpeed;
        rigidBody.velocity = new Vector3(horizontalInput, verticalInput);
    }

}
