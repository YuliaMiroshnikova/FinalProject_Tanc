using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    public float maxSpeed = 100f; 
    public float acceleration = 2f; 
    private Rigidbody _tank;
    public float rotationSpeed = 100f;
   
    
    public float accelerateAngle = 10f;
    private Vector3 currentVelocity;
    
    


    void Awake()
    {
        _tank = GetComponent<Rigidbody>();
    }
    

    void FixedUpdate()
    {
        MoveTank();
        
    }


    private void MoveTank()
    {
        float horMove = Input.GetAxis("Horizontal");
        float vertMove = Input.GetAxis("Vertical");
        
        Vector3 desiredVelocity = transform.forward * vertMove * maxSpeed;
        currentVelocity = Vector3.Lerp(_tank.velocity, desiredVelocity, acceleration * Time.fixedDeltaTime);
        Vector3 force = (currentVelocity - _tank.velocity) / Time.fixedDeltaTime;
        _tank.AddForce(force, ForceMode.Force);
        
        
        float rotationAngle = horMove * rotationSpeed * Time.fixedDeltaTime;
        Quaternion finalRotation = Quaternion.Euler(0, rotationAngle, 0);
        _tank.MoveRotation(_tank.rotation * finalRotation);
    }
    
    
    
}






// DRAFTS
        
        // ПРОСТОЕ ПЕРЕДВИЖЕНИЕ на всякий случай
        // private void MoveTank()
        // {
        // float horMove = Input.GetAxis("Horizontal");
        // float vertMove = Input.GetAxis("Vertical");
        //
        //
        // float rotationAngle = horMove * rotationSpeed * Time.fixedDeltaTime;
        // Quaternion finalRotation = Quaternion.Euler(0, rotationAngle, 0);
        // _tank.MoveRotation(_tank.rotation * finalRotation);
        //
        //
        // Vector3 localMoveDirection = new Vector3(0f, 0f, vertMove).normalized;
        // Quaternion currentRotation = _tank.rotation;
        // Vector3 moveDirection = currentRotation * localMoveDirection;
        // _tank.velocity = moveDirection * speed;
        // }
        


        // А ТУТ ПЕРЕМЕЩЕНИЕ С ПОМОЩЬЮ velicity на всякий случай
        // float targetSpeed = maxSpeed * vertMove;
        //
        // currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.fixedDeltaTime);
        //
        // Vector3 movement = transform.forward * currentSpeed;
        // _tank.velocity = new Vector3(movement.x, _tank.velocity.y, movement.z);
    

