using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    private float moveInput;
    private float turnInput;
    private bool IsCarGrounded;

    public float ForwardAcceleration;
    public float BackAcceleration;
    public float turnSpeed;
    public LayerMask groundLayer;
    

    public Rigidbody sphereRB;


    // Start is called before the first frame update
    void Start()
    {
        sphereRB.transform.parent = null; //detach rigidbody from car - makes the car not gradually increase speed
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        // Going forwards and going backwards
        moveInput *= moveInput > 0 ? ForwardAcceleration : BackAcceleration; 

        //sets car position to sphere
        transform.position = sphereRB.transform.position;

        //sets car rotation
        
        if (sphereRB.velocity.magnitude > 0)
        {
            float newRotation = turnInput * turnSpeed * (sphereRB.velocity.magnitude / 50) * Time.deltaTime;
            transform.Rotate(0, newRotation, 0, Space.World);
        }

        //raycast ground check
        RaycastHit hit;
        IsCarGrounded = Physics.Raycast(transform.position, -transform.up, out hit, groundLayer);

    }

    void FixedUpdate()
    {
        sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
    }
}
