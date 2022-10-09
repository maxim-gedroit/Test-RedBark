using System;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameView _view;
    [SerializeField] private SpawnController _spawnController;

    private GameData _data;

    private void Awake()
    {
        _data = new GameData();
        _spawnController.OnDestroyEnemy += UpdateCounter;
        _view.OnQuit += Application.Quit;
    }

    private void Start()
    {
        _view.SetEnemyCount(_data.EnemyCount);
        _spawnController.Init(_data.EnemyCount);
    }

    private void UpdateCounter()
    {
        _data.EnemyCount--;
        _view.SetEnemyCount(_data.EnemyCount);
    }

    private void Update()
    {
        CalculateGameTimer();
    }

    private void CalculateGameTimer()
    {
        if (_data.time > 0)
        {
            _data.time -= Time.deltaTime;
            _view.SetTimer(_data.time);
        }
        else
        {
            if (!_data.isLevelEnd)
            {
                _data.isLevelEnd = true;
                if (_data.EnemyCount == 0)
                    CompleteGame();
                else
                    LooseGame();
            }
        }
    }

    private void LooseGame()
    {
        PopupManager.Instance.Show("lose");
    }
    
    private void CompleteGame()
    {
        PopupManager.Instance.Show("complete");
    }

    private void OnDestroy()
    {
        _spawnController.OnDestroyEnemy -= UpdateCounter;
        _view.OnQuit -= Application.Quit;
    }
}