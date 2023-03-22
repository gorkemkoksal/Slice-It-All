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
    private void OnTriggerEnter(Collider other)
    {
        print(".l.");
        playerRb.velocity = Vector3.zero;
        playerRb.AddForce(backForce);
        var rotateAmount = Random.Range(50, 100);
        knife.DOLocalRotate(new Vector3(0, 0, knife.localRotation.z + rotateAmount), 1f, RotateMode.FastBeyond360);
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
