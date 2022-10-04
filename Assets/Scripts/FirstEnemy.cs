using System;
using System.Collections;
using UnityEngine;

public class FirstEnemy : BaseEnemy
{
    public override void Init()
    {
        var centerOfMass = _rigidbody.centerOfMass;
        centerOfMass = new Vector3(centerOfMass.x, centerOfMass.y - .2f, centerOfMass.z);
        _rigidbody.centerOfMass = centerOfMass;
    }
    
    private void FixedUpdate()
    {
        if(transform.position.y < 3f)
            CalculateMovement();
    }
    
    private void CalculateMovement(){
        _rigidbody.MovePosition(transform.position + transform.forward * (Time.deltaTime * Speed));
        
    }
}