using System;
using UnityEngine;

public class KnifeHit : MonoBehaviour
{
    public static Action OnAnyStab;
    public static Action OnAnyCut;

    [SerializeField] private CoinManager coinManager;
    private bool CoinStop = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plane"))
        {
            OnAnyStab();
        }
        else if (other.CompareTag("MultipleCuttables"))
        {
            OnAnyCut();
        }
        else if (other.CompareTag("Multiple5") && CoinStop)
        {
            coinManager.MultipleCoinx5();
            print("5 ile Çaprtý.");
            CoinStop = false;
            OnAnyStab();
        }
        else if (other.CompareTag("Multiple10") && CoinStop)
        {
            coinManager.MultipleCoinx10();
            print("10 ile Çaprtý.");
            CoinStop = false;
            OnAnyStab();
        }
        else if (other.CompareTag("Multiple15") && CoinStop)
        {
            coinManager.MultipleCoinx15();
            print("15 ile Çaprtý.");
            CoinStop = false;
            OnAnyStab();
        }
        else if (other.CompareTag("Multiple20") && CoinStop)
        {
            coinManager.MultipleCoinx20();
            print("20 ile Çaprtý.");
            CoinStop = false;
            OnAnyStab();
        }
        else if (other.CompareTag("Multiple30") && CoinStop)
        {
            coinManager.MultipleCoinx30();
            print("30 ile Çaprtý.");
            CoinStop = false;
            OnAnyStab();
        }
        else if (other.CompareTag("Multiple50") && CoinStop)
        {
            coinManager.MultipleCoinx50();
            print("50 ile Çaprtý.");
            CoinStop = false;
            OnAnyStab();
        }
    }
}
//((transform.parent.rotation.x > 315f && transform.parent.rotation.x < 350f) || 
//            (transform.parent.rotation.x > -45f && transform.parent.rotation.x < -7f)))