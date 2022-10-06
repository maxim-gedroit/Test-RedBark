using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseEnemy : MonoBehaviour
{
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
}
