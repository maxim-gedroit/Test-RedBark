using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseEnemy : MonoBehaviour, ITarget
{
    public static event Action OnDestroy;
    public HpBar _hpBar;
    public int Hp = 3;
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
        OnDestroy?.Invoke();
        Destroy(gameObject);
    }
}
