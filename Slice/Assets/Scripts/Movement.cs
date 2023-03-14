using DG.Tweening;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody playerRb;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        }
    }
}
