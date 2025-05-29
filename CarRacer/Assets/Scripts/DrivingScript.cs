using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingScript : MonoBehaviour
{
    public WheelScript[] wheels;
    public float torque = 200f;
    public float maxSteerAngle = 30f;
    public float maxBrakeTorque = 500f;
    public float maxSpeed = 200f;
    public Rigidbody rb;
    public float currentSpeed;

    public void Drive(float acceleration, float brake, float steer)
    {
        acceleration = Mathf.Clamp(acceleration, -1f, 1f);
        steer = Mathf.Clamp(steer, -1f, 1f) * maxSteerAngle; // pomno¿yæ przez wartoœci
        brake = Mathf.Clamp01(brake) * maxBrakeTorque; // pomno¿yæ przez wartoœci

        float thrustTorque = 0f;

        if (currentSpeed < maxSpeed)
        {
            thrustTorque = acceleration * torque;
        }

        foreach (WheelScript wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = thrustTorque;

            if (wheel.isFrontWheel)
            {
                wheel.wheelCollider.steerAngle = steer;
            }
            else
            {
                wheel.wheelCollider.brakeTorque = brake;
            }

            Quaternion wheelRotation;
            Vector3 wheelPosition;
            wheel.wheelCollider.GetWorldPose(out wheelPosition, out wheelRotation);
            wheel.wheelGO.transform.position = wheelPosition;
            wheel.wheelGO.transform.rotation = wheelRotation;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
