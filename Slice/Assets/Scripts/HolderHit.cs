using DG.Tweening;
using UnityEngine;

public class HolderHit : MonoBehaviour
{
    private Rigidbody playerRb;
    private Vector3 backForce = new Vector3(0, 50, 50);
    private Transform knife;
    private void Start()
    {
        playerRb = transform.parent.parent.GetComponent<Rigidbody>();
        knife = transform.parent;
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(".l.");
        playerRb.AddForce(backForce);
        var rotateAmount = Random.Range(50, 100);
        knife.DOLocalRotate(Vector3.forward * rotateAmount, 1f, RotateMode.FastBeyond360);
    }
}
