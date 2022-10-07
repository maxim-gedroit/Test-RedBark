using System;
using UnityEngine;

public class Edge : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        try
        {
            var enemy = collision.gameObject.GetComponent<BaseEnemy>();
            enemy.Dead();
        }
        catch 
        {
        }
       
    }
}
