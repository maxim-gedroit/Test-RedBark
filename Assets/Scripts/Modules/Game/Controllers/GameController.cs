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
        _spawnController.OnDestroyEnemy += UpdateCounter;
        _enemyLabel.text = EnemyCount.ToString();
    }

    private void Start()
    {
        _enemyLabel.text = "enemy: " + EnemyCount.ToString();
        _spawnController.Init(EnemyCount);
    }

    private void UpdateCounter()
    {
        EnemyCount--;
        _enemyLabel.text = "enemy: " + EnemyCount.ToString();
    }

    private void Update()
    {
        CalculateGameTimer();
    }

    private void CalculateGameTimer()
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
                if (EnemyCount == 0)
                    CompleteGame();
                else
                    LoseGame();
            }
        }
    }

    private void LoseGame()
    {
        PopupManager.Instance.Show("lose");
    }
    
    private void CompleteGame()
    {
        PopupManager.Instance.Show("complete");
    }
}