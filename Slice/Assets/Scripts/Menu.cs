using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Menu : MonoBehaviour
{
    [SerializeField] private Text TapToFlip;
    public GameObject MainMenu, MenuInGame, WinPanel, MarketMenu;
    public bool MarketisOpen = false;

    void Start()
    {
        TapToFlip.transform.DOScale(1.1f, 0.5f).SetLoops(1000, LoopType.Yoyo).SetEase(Ease.InOutFlash);
    }

    void Update()
    {
        if (!MarketisOpen)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                MarketMenu.SetActive(true);
            }
        }
    }


    private void OpenMarketMenu()
    {

    }

    public void OpenWinPanel()
    {
        WinPanel.gameObject.SetActive(true);
    }
}
