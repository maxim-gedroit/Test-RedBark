using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Invoke("DeleteSelf",3f);
    }
    
    private void DeleteSelf()
    {
        Destroy(gameObject);
    }

}
