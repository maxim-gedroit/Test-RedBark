using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Rigidbody _bullet;

    public void Fire()
    {
        Rigidbody bulletClone = (Rigidbody) Instantiate(_bullet, transform.position, Quaternion.identity);
        bulletClone.velocity = transform.forward * 50f;
    }
}
