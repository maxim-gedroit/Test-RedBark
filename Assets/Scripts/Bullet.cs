using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Radius = 20f;
    public float Force = 20f;
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
        //Explode();
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
        Destroy(gameObject);
        // Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
    }

}
