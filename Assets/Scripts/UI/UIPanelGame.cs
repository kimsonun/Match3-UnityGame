using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelGame : MonoBehaviour,IMenu
{
    public Text LevelConditionView;

    [SerializeField] private Button btnPause;
    [SerializeField] private Button btnRestart;

    private UIMainManager m_mngr;
    private GameManager m_gameManager;

    private void Awake()
    {
        btnPause.onClick.AddListener(OnClickPause);
        btnRestart.onClick.AddListener(OnClickRestart);
    }

    private void OnDestroy()
    {
        if (btnPause) btnPause.onClick.RemoveAllListeners();
        if (btnRestart) btnRestart.onClick.RemoveAllListeners();
    }

    public void Setup(UIMainManager mngr)
    {
        Setup(mngr, null);
    }

    private void OnClickPause()
    {
        m_mngr.ShowPauseMenu();
    }

    private void OnClickRestart()
    {
        if (m_gameManager != null)
        {
            m_gameManager.RestartCurrentLevel();
        }
    }

    public void Setup(UIMainManager mngr, GameManager gameManager)
    {
        m_mngr = mngr;
        m_gameManager = gameManager;
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
