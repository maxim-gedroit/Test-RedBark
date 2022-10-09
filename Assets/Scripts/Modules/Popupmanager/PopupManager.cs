using System;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [Serializable]
    private class Data
    {
        public string Id;
        public BasePopup Popup;
    }

    public static PopupManager Instance;

    [SerializeField] private List<Data> _popups = new List<Data>();


    private string _activePopup;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void Show(string id)
    {
        CloseAll();
        
        foreach (var item in _popups)
        {
            if (item.Id == id)
            {
                item.Popup.gameObject.SetActive(true);
                item.Popup.OnShow();
                _activePopup = id;
            }
        }
    }

    public void CloseAll()
    {
        foreach (var item in _popups)
        {
            item.Popup.OnHide();
            item.Popup.gameObject.SetActive(false);
        }
    }
}