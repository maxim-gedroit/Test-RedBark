using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class SecondEnemy : BaseEnemy
{
    [SerializeField] private ParticleSystem _particle;
    private Renderer _renderer;
    private bool isJump;
    public Vector3 _direction;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public override void Init(Transform _transform)
    {
        base.Init(_transform);
        Hp = 3;
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

    public override void Damage()
    {
        base.Damage(); 
        _hpBar.Damage();
        Hp--;
        if (Hp == 0)
        {
            transform.DOScale(Vector3.zero, 1).OnComplete(()=>{Dead();});
        }
    }

    private void Jump()
    {
        _rigidbody.velocity = _direction;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        _direction = new Vector3(Random.Range(-6f,6f),Speed,Random.Range(-3f,3f));
    }
}