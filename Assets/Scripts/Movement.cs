using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float rotationSpeed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RotationInput();
        MovementInput();
    }
    void RotationInput()
    {
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.E))
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    void MovementInput()
    {
        // Raw for now because of no smoothing (better for keyboard), for Arduino maybe without raw.
        float inputAxisX = Input.GetAxisRaw("Horizontal");
        float inputAxisZ = Input.GetAxisRaw("Vertical");
        Vector3 movement = (transform.forward * inputAxisX) + (transform.right * inputAxisZ);
        movement = movement.normalized * moveSpeed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
}
