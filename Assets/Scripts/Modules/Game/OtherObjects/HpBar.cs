using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private List<GameObject> bar;

    public void Init(Transform target)
    {
        _target = target;
    }

    public void Damage()
    {
        try
        {
            var index = bar.Count - 1;
            bar[index].SetActive(false);
            bar.Remove(bar[index]);
        }
        catch
        {
            
        }
        
    }

    private void Update()
    {
        transform.LookAt(_target,Vector3.up);
    }
}
