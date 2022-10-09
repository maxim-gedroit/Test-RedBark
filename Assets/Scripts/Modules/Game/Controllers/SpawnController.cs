using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour
{
    public event Action OnDestroyEnemy;
    [SerializeField] private Transform _target;
    [SerializeField] private BaseEnemy[] _enemies;
    private Coroutine _coroutine;
    private int _count;
    private void Awake()
    {
        BaseEnemy.OnDestroy += DestroyEnemy;
    }

    private void DestroyEnemy()
    {
        OnDestroyEnemy?.Invoke();
        if (_count == 0)
        {
            StopCoroutine(_coroutine);
        }
    }
    

    public void Init(int _enemyCount)
    {
        _count = _enemyCount;
        _coroutine = StartCoroutine("Spawner");
    }
    
    private IEnumerator Spawner()
    {
        while (_count != 0)
        {
            var enemyIndex = Random.Range(0,2);
            var enemy = Instantiate(_enemies[enemyIndex], transform.position, Quaternion.identity);
            enemy.Init(_target);
            _count--;
            yield return new WaitForSeconds(.5f);
        }
    }

    private void OnDestroy()
    {
        BaseEnemy.OnDestroy -= DestroyEnemy;
    }
}