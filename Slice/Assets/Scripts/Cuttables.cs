using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuttables : MonoBehaviour
{
    [SerializeField] bool forceAllCuttedObjects;
    [SerializeField] private Transform leftPart;
    [SerializeField] private Transform rightPart;
    [SerializeField] private MeshRenderer meshRenderer;

    List<Transform> cuttedObjects = new List<Transform>();
    private bool isCutted;

    private void OnTriggerEnter(Collider other)
    {
        if (isCutted) { return; }
        print("...");
        if (other.CompareTag("knife"))
        {
            meshRenderer.enabled = false;
            var left = Instantiate(leftPart, transform.position - new Vector3(transform.localScale.x / 4, 0, 0), Quaternion.identity);
            var right = Instantiate(rightPart, transform.position + new Vector3(transform.localScale.x / 4, 0, 0), Quaternion.identity);
            left.SetParent(transform);
            right.SetParent(transform);
            cuttedObjects.Add(left);
            cuttedObjects.Add(right);

            if (forceAllCuttedObjects) ForceCuttedOBjects(2);
            else ForceCuttedOBjects(1);

            isCutted = true;
        }
    }
    private void ForceCuttedOBjects(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var rb = cuttedObjects[i].gameObject.GetComponent<Rigidbody>();

            var force = i == 0 ? new Vector3(-100, 0, 0) : new Vector3(100, 0, 0);

            rb.AddForce(force * cuttedObjects[i].transform.localPosition.x * 5);
        }
    }
}
