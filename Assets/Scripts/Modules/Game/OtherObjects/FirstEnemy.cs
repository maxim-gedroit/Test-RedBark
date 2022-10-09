using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class FirstEnemy : BaseEnemy
{
    private Vector3 direction;

    public override void Init(Transform _transform)
    {
        base.Init(_transform);
        var centerOfMass = _rigidbody.centerOfMass;
        centerOfMass = new Vector3(centerOfMass.x, centerOfMass.y - .2f, centerOfMass.z);
        _rigidbody.centerOfMass = centerOfMass;
        direction = Vector3.back;
    }
    
    
    private void FixedUpdate()
    {
        MoveForward();
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

    public override void Damage()
    {
        base.Damage();
        _hpBar.Damage();
        transform.DOScale(transform.localScale / 1.8f, 1);
        Hp--;
        if (Hp == 0)
        {
            transform.DOScale(Vector3.zero, 1).OnComplete(()=>{Dead();});
        }
    }
}