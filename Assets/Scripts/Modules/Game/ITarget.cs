using UnityEngine;

interface ITarget
{
    void Damage();
    void Dead();
    void Init(Transform aim);
}
