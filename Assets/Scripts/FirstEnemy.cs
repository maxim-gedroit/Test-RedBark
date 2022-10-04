using System;
using System.Collections;
using UnityEngine;

public class FirstEnemy : BaseEnemy
{
    private bool isCollision;
    public Vector3 angleVelocity;
    private int side = 1;

    private void Start()
    {
        StartCoroutine(SwitchSide());
    }

    IEnumerator SwitchSide()
    {
        while (true)
        {
            side *= -1;
            yield return new WaitForSeconds(8f);
        }
    }

    public override void Init()
    {
        var centerOfMass = _rigidbody.centerOfMass;
        centerOfMass = new Vector3(centerOfMass.x, centerOfMass.y - .2f, centerOfMass.z);
        _rigidbody.centerOfMass = centerOfMass;
        
        angleVelocity = new Vector3(0, 70, 0);
    }
    
    private void FixedUpdate()
    {
        if (transform.position.y < 3.2f)
        {
            CalculateMovement();
            CalculateRotation();
        }
    }
    
    private void CalculateMovement(){
        
        if(!isCollision)
            _rigidbody.MovePosition(transform.position + transform.forward * (Time.fixedDeltaTime * Speed));
    }

    private void CalculateRotation()
    {
        if (isCollision)
        {
            Quaternion deltaRotation = Quaternion.Euler(angleVelocity * ((side) * Time.fixedDeltaTime));
            _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
        }
       
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.layer == 6)
            return;

        isCollision = true;
    }

    private void OnCollisionExit(Collision other)
    {
        isCollision = false;
    }
}