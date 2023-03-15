using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuttables : MonoBehaviour
{
    [SerializeField] private Transform leftPart;
    [SerializeField] private Transform rightPart;
    [SerializeField] private MeshRenderer meshRenderer;
    private bool isCutted;

    private void OnTriggerEnter(Collider other)
    {
        if (isCutted) { return; }
        print("...");
        if (other.CompareTag("knife"))
        {
            meshRenderer.enabled = false;
            Instantiate(leftPart, transform.position - new Vector3(transform.localScale.x / 4, 0, 0), Quaternion.identity);
            Instantiate(rightPart, transform.position + new Vector3(transform.localScale.x / 4, 0, 0), Quaternion.identity);
            var rightRb = rightPart.GetComponent<Rigidbody>();
            rightRb.isKinematic = false;
            isCutted = true;
        }
    }
}
