using System;
using UnityEngine;
using TMPro;

public class KnifeHit : MonoBehaviour
{
    public static Action OnAnyStab;
    public static Action OnAnyCut;
    [SerializeField] private Movement movement;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private GameManager gameManager;
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
            print(other.name);
            var text = other.transform.GetChild(1).GetComponent<TextMeshPro>();
            var multiplier = int.Parse(text.text);
            print(multiplier);

            coinManager.MultipleCoin(multiplier);
            CoinStop = false;
            OnAnyStab();
            movement.IsEnded = true;

            gameManager.EndLevel();
        }
    }
    //Ata ogren bunlari
    // Görkem üþenme kanka
}