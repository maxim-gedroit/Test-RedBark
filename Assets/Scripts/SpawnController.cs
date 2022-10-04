using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private BaseEnemy[] _enemies;

    private void Start()
    {
        StartCoroutine("Spawner");
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            var enemyIndex = Random.Range(0,1);
            var enemy = Instantiate(_enemies[enemyIndex], transform.position, Quaternion.identity);
            enemy.Init();
            yield return new WaitForSeconds(4f);
        }
    }
}