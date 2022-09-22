using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMovement : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider rearRight;
    [SerializeField] WheelCollider rearLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform rearRightTransform;
    [SerializeField] Transform rearLeftTransform;

    public float acceleration = 1000f;
    public float braking = 800f;
    public float turnAngle = 20f;

    private float currentAcceleration = 0f;
    private float currentBraking = 0f;
    private float currentTurnAngle = 0f;
    

    private void FixedUpdate()
    {
        //Get acceleration from vertical axis (W)
        currentAcceleration = acceleration * (20 * Input.GetAxis("Vertical"));


        //If we press "S" we give current braking a value
        if (Input.GetKey(KeyCode.Space))
            currentBraking = braking;
        else
            currentBraking = 0f;

        //Acceleration
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        //Braking
        frontRight.brakeTorque = currentBraking;
        frontLeft.brakeTorque = currentBraking;
        rearRight.brakeTorque = currentBraking;
        rearLeft.brakeTorque = currentBraking;

        // Steering
        currentTurnAngle = turnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;
    }
    void UpdateWheel(WheelCollider col, Transform trans)
    {
        //Get wheel collider state
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        //Set wheel transform state
        trans.position = position;
        trans.rotation = rotation;
    }
}