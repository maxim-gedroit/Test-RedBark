using Cysharp.Threading.Tasks;
using Modules.SceneManager;
using TMPro;
using UnityEngine;
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
        PopupManager.Instance.CloseAll();
        SceneSwitcher.Load("Splash").Forget();
    }

    public override void OnHide()
    {
        base.OnShow();
        _restart.onClick.RemoveListener(RestartLevel);
    }
}
