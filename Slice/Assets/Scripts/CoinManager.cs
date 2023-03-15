using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private GameObject PileOfCoinParent;
    [SerializeField] private Text Counter;
    [SerializeField] private Vector3[] InitalPosition;
    [SerializeField] private Quaternion[] InitalRotation;
    [SerializeField] private int CoinNo;

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
        Reset();

        var delay = 0f;

        PileOfCoinParent.SetActive(true);

        for (int i = 0; i < PileOfCoinParent.transform.childCount; i++)
        {
            PileOfCoinParent.transform.GetChild(i).DOScale(1f,0.3f).SetDelay(delay).SetEase(Ease.OutBack);

            PileOfCoinParent.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector2(646f, 460f), 0.8f).
                SetDelay(delay + 0.5f).SetEase(Ease.InBack);

            PileOfCoinParent.transform.GetChild(i).DORotate(Vector3.zero,0.05f).SetDelay(delay + 0.5f).SetEase(Ease.Flash).
                OnComplete(CountCoinsByComplete);

            PileOfCoinParent.transform.GetChild(i).DOScale(0f,0.3f).SetDelay(delay + 1.8f).SetEase(Ease.OutBack);

            delay += 0.1f;
        }
    }

    private void CountCoinsByComplete()
    {
        PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") + 1);
        Counter.text = PlayerPrefs.GetInt("Coin").ToString();
    }

}
