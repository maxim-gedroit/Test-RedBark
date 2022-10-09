using System;
using TMPro;
using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] private TMP_Text _enemyLabel;
    [SerializeField] private TMP_Text _timeLabel;
    
    public void SetEnemyCount(int enemyCount)
    {
        _enemyLabel.text = "enemy: " + enemyCount.ToString();
    }
    
    public void SetTimer(float time)
    {
        _timeLabel.text = "time: " + Mathf.Round(time).ToString();
    }
}