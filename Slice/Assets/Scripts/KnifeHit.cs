using System;
using UnityEngine;

public class KnifeHit : MonoBehaviour
{
    public static Action OnAnyStab;
    public static Action OnAnyCut;
    [SerializeField] private Movement movement;
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
            CoinStop = false;
            OnAnyStab();
            movement.IsEnded = true;
        }
        else if (other.CompareTag("Multiple10") && CoinStop)
        {
            coinManager.MultipleCoinx10();
            CoinStop = false;
            OnAnyStab();
            movement.IsEnded = true;

        }
        else if (other.CompareTag("Multiple15") && CoinStop)
        {
            coinManager.MultipleCoinx15();
            CoinStop = false;
            OnAnyStab();
            movement.IsEnded = true;

        }
        else if (other.CompareTag("Multiple20") && CoinStop)
        {
            coinManager.MultipleCoinx20();
            CoinStop = false;
            OnAnyStab();
            movement.IsEnded = true;

        }
        else if (other.CompareTag("Multiple30") && CoinStop)
        {
            coinManager.MultipleCoinx30();
            CoinStop = false;
            OnAnyStab();
            movement.IsEnded = true;

        }
        else if (other.CompareTag("Multiple50") && CoinStop)
        {
            coinManager.MultipleCoinx50();
            CoinStop = false;
            OnAnyStab();
            movement.IsEnded = true;

        }
    }
}