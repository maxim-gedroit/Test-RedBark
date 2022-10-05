using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class SecondEnemy : BaseEnemy
{
    private bool isJump;
    private Vector3 _direction = new Vector3(0f,9f,-3);

    public override void Init()
    {
        base.Init();
    }

    private void FixedUpdate()
    {
        if (transform.position.y < 7f)
        {
            if (!isJump)
            {
                isJump = true;
                Jump();
            }
        }
        else
        {
            isJump = false;
        }

        if (transform.rotation == Quaternion.identity)
            return;

        _rigidbody.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.identity,80f * Time.deltaTime);

    }
    
    private void Jump()
    {
        _rigidbody.velocity = _direction;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        _direction = new Vector3(Random.Range(-6f,6f),9f,Random.Range(-3f,3f));
    }
}