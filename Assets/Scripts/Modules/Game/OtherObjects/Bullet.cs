using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem ExplosionEffect;
    private float Radius = 15f;
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
                var root = overlappedColliders[i].GetComponent<ITarget>();
                if (root != null)
                    root.Damage();
            }
        }
        
        Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        DeleteSelf();
    }
}