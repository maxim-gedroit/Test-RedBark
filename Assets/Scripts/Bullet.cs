using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem ExplosionEffect;
    private float Radius = 50f;
    private float Force = 500f;
    void Start()
    {
        Invoke("DeleteSelf",3f);
    }
    
    private void DeleteSelf()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("explde");
        Explode();
    }

    public void Explode()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, Radius);
        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(Force,transform.position,Radius);
            }
        }
        
        Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}