using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompleteLevelPopup : BasePopup
{
    [SerializeField] private Button _restart;
    [SerializeField] private TMP_Text _label;
    public override void OnShow()
    {
        base.OnShow();
        _label.text = "You Win";
        _restart.onClick.AddListener(RestartLevel);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public override void OnHide()
    {
        base.OnShow();
        _restart.onClick.RemoveListener(RestartLevel);
    }
}
