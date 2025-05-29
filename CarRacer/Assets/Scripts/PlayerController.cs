using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private DrivingScript drivingScript;

    void Start()
    {
        
    }

    void Update()
    {
        float accel = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");
        float brake = Input.GetAxis("Jump");

        drivingScript.Drive(accel, brake, steer);
    }
}
