using System;
using UnityEngine;

public class KnifeHit : MonoBehaviour
{
    public static Action OnAnyStab;
    public static Action OnAnyCut;
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
    }
}
//((transform.parent.rotation.x > 315f && transform.parent.rotation.x < 350f) || 
//            (transform.parent.rotation.x > -45f && transform.parent.rotation.x < -7f)))