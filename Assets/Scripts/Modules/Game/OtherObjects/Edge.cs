using System;
using UnityEngine;

public class Edge : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        try
        {
            var enemy = collision.gameObject.GetComponent<ITarget>();
            enemy.Dead();
        }
        catch 
        {
        }
       
    }
}
