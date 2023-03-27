using System;
using UnityEngine;

public class KnifeHit : MonoBehaviour
{
    public static Action OnAnyStab;
    public static Action OnAnyCut;

    [SerializeField] private CoinManager coinManager;
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
        else if (other.CompareTag("Multiple5"))
        {
            coinManager.MultipleCoinx5();
            OnAnyStab();
        }
        else if (other.CompareTag("Multiple10"))
        {
            coinManager.MultipleCoinx10();
            OnAnyStab();
        }
        else if (other.CompareTag("Multiple15"))
        {
            coinManager.MultipleCoinx15();
            OnAnyStab();
        }
        else if (other.CompareTag("Multiple20"))
        {
            coinManager.MultipleCoinx20();
            OnAnyStab();
        }
        else if (other.CompareTag("Multiple30"))
        {
            coinManager.MultipleCoinx30();
            OnAnyStab();
        }
        else if (other.CompareTag("Multiple50"))
        {
            coinManager.MultipleCoinx50();
            OnAnyStab();
        }
    }
}
//((transform.parent.rotation.x > 315f && transform.parent.rotation.x < 350f) || 
//            (transform.parent.rotation.x > -45f && transform.parent.rotation.x < -7f)))