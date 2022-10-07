using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseEnemy : MonoBehaviour
{
    public static event Action<BaseEnemy> _destroy;
    public HpBar _hpBar;
    public int Hp;
    public float Speed;
    protected Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void Init(Transform _transform)
    {
        _hpBar.Init(_transform);
    }

    public virtual void Damage()
    {
        
    }

    public virtual void Dead()
    {
        _destroy?.Invoke(this);
        Destroy(gameObject);
    }
}
