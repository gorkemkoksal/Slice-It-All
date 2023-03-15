using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Menu : MonoBehaviour
{
    [SerializeField] private Text TapToFlip;

    void Start()
    {
        TapToFlip.transform.DOScale(1.1f, 0.5f).SetLoops(1000, LoopType.Yoyo).SetEase(Ease.InOutFlash);
    }

    void Update()
    {
        
    }
}
