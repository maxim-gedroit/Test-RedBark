using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour
{
    public event Action destroyenemy;
    [SerializeField] private Transform _target;
    [SerializeField] private BaseEnemy[] _enemies;
    private int count = 200;
    private Coroutine _coroutine;
    private void Awake()
    {
        BaseEnemy._destroy += (baseEnemy) =>
        {
            destroyenemy?.Invoke();
            if (count == 0)
            {
                StopCoroutine(_coroutine);
            }
        };
    }

    private void Start()
    {
       _coroutine = StartCoroutine("Spawner");
    }

    private IEnumerator Spawner()
    {
        while (count != 0)
        {
            Debug.Log("spawn");
            var enemyIndex = Random.Range(0,2);
            var enemy = Instantiate(_enemies[enemyIndex], transform.position, Quaternion.identity);
            enemy.Init(_target);
            count--;
            yield return new WaitForSeconds(.5f);
        }
    }
}