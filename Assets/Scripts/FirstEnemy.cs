using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class FirstEnemy : BaseEnemy
{
    private Vector3 direction;
    private bool isGround => transform.position.y < 3.2f;

    public override void Init()
    {
        var centerOfMass = _rigidbody.centerOfMass;
        centerOfMass = new Vector3(centerOfMass.x, centerOfMass.y - .2f, centerOfMass.z);
        _rigidbody.centerOfMass = centerOfMass;
        direction = Vector3.back;
    }
    
    
    private void FixedUpdate()
    {
        if (isGround)
        {
            MoveForward();
        }
    }
    
    private void MoveForward()
    {
        _rigidbody.MovePosition(transform.position + direction * (Time.fixedDeltaTime * Speed));
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
            return;

        direction = new Vector3(Random.Range(-1f,1f),0f,Random.Range(-1f,1f));
    }
   
}