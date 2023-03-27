using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private int Coin;
    [SerializeField] private int tempCoin;
    [SerializeField] private GameObject PileOfCoinParent;
    [SerializeField] private Text Counter;
    public Text tempCoinText;
    [SerializeField] private Vector3[] InitalPosition;
    [SerializeField] private Quaternion[] InitalRotation;
    [SerializeField] private int CoinNo;

    public Action OnScore;

    private int y;
    private int x;

    private void Awake()
    {
        DOTween.SetTweensCapacity(1000, 50);
        Counter.text = PlayerPrefs.GetInt("Coin").ToString();
    }
    private void OnEnable()
    {
        Cuttables.OnAnyCut += Cuttables_OnAnyCut;
    }
    private void OnDisable()
    {
        Cuttables.OnAnyCut -= Cuttables_OnAnyCut;
    }

    void Start()
    {
        InitalPosition = new Vector3[CoinNo];
        InitalRotation = new Quaternion[CoinNo];

        for (int i = 0; i < PileOfCoinParent.transform.childCount; i++)
        {
            InitalPosition[i] = PileOfCoinParent.transform.GetChild(i).position;
            InitalRotation[i] = PileOfCoinParent.transform.GetChild(i).rotation;
        }
    }
    public void GetCoin(int coinPoint)
    {
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + coinPoint);
        Counter.text = PlayerPrefs.GetInt("Coin").ToString();

        tempCoin += coinPoint;
    }

    private void Reset()
    {
        for (int i = 0; i < PileOfCoinParent.transform.childCount; i++)
        {
            PileOfCoinParent.transform.GetChild(i).position = InitalPosition[i];
            PileOfCoinParent.transform.GetChild(i).rotation = InitalRotation[i];
        }
    }

    public void RewardPileOfCoin(int noCoin)
    {
        var delay = 0f;

        PileOfCoinParent.SetActive(true);

        y = tempCoin / 10;


        for (int i = 0; i < PileOfCoinParent.transform.childCount; i++)
        {
            PileOfCoinParent.transform.GetChild(i).DOScale(2f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);

            PileOfCoinParent.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector2(227f, 1519f), 0.8f).
                SetDelay(delay + 0.5f).SetEase(Ease.InBack);

            PileOfCoinParent.transform.GetChild(i).DORotate(Vector3.zero, 0.05f).SetDelay(delay + 0.5f).SetEase(Ease.Flash).
                OnComplete(CountCoinsByComplete);

            PileOfCoinParent.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(delay + 1.8f).SetEase(Ease.OutBack);

            delay += 0.1f;
        }

        //Reset();

        ResetTempCoin();
    }
    private void Cuttables_OnAnyCut()
    {
        GetCoin(10);
        tempCoinText.text = tempCoin.ToString();
    }

    private void CountCoinsByComplete()
    {
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + y);
        Counter.text = PlayerPrefs.GetInt("Coin").ToString();
    }

    private void ResetTempCoin()
    {
        tempCoin = 0;
        tempCoinText.text = tempCoin.ToString();
    }

    public void MultipleCoin(int multiplierAmount)
    {
        tempCoin = multiplierAmount * tempCoin;
        tempCoinText.text = "+ " + tempCoin.ToString();
    }
}
