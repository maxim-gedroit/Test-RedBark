using System;
using Cysharp.Threading.Tasks;
using Modules.SceneManager;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_Text _enemyLabel;
    [SerializeField] private TMP_Text _timeLabel;
    [SerializeField] private SpawnController _spawnController;

    private bool isLevelEnd;
    
    private int EnemyCount = 200;
    private float time = 120f;

    private void Awake()
    {
        _spawnController.destroyenemy += UpdateCounter;
        _enemyLabel.text = EnemyCount.ToString();
    }

    private void Start()
    {
        _enemyLabel.text = "enemy: " + EnemyCount.ToString();
    }

    private void UpdateCounter()
    {
        EnemyCount--;
        _enemyLabel.text = "enemy: " + EnemyCount.ToString();
    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            _timeLabel.text = "time: " + Mathf.Round(time).ToString();
        }
        else
        {
            if (!isLevelEnd)
            {
                isLevelEnd = true;
                SceneSwitcher.Load("Splash").Forget();
            }

        }

    }
}