using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHit : MonoBehaviour
{
    private Rigidbody playerRb;
    private Movement movement;
    private void Start()
    {
        playerRb = transform.parent.GetComponent<Rigidbody>();
        movement = transform.parent.GetComponent<Movement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plane"))
        {
            playerRb.isKinematic = true;
            playerRb.velocity = Vector3.zero;
            movement.SetIsStabbed(true);
        }
    }


}
