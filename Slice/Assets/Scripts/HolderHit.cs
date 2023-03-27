using System;
using UnityEngine;

public class HolderHit : MonoBehaviour
{
    public static Action OnAnyBackHit;
    private void OnTriggerEnter(Collider other)
    {
        OnAnyBackHit();
        print(other.name);
    }
}
