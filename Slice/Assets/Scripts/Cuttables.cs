using System.Collections.Generic;
using UnityEngine;
using System;

public class Cuttables : MonoBehaviour
{
    [SerializeField] private Transform leftPart;
    [SerializeField] private Transform rightPart;
    [SerializeField] private GameObject mainObject;
    [SerializeField] private bool isLego;
    [Range(0, 2)][SerializeField] private int numberOfPiecesToForce;
    [SerializeField] private Collider collider;

    private List<Rigidbody> rigidbodies = new List<Rigidbody>();

    private bool isCutted;

    private Material legoMaterial;

    public static Action OnAnyCut;

    private void Start()
    {
        if (TryGetComponent(out BoxCollider bCollider))
        {
            collider = bCollider;
        }
        else if(TryGetComponent(out SphereCollider sCollider))
        {
            collider = sCollider;
        }

        rigidbodies.Add(transform.GetChild(1).GetComponent<Rigidbody>());
        rigidbodies.Add(transform.GetChild(2).GetComponent<Rigidbody>());

        if (isLego == false) return;
        legoMaterial = transform.GetChild(0).GetComponent<MeshRenderer>().material;
        transform.GetChild(1).GetComponent<MeshRenderer>().material = legoMaterial;
        transform.GetChild(2).GetComponent<MeshRenderer>().material = legoMaterial;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isCutted) { return; }

        if (other.CompareTag("knife"))
        {
            isCutted = true;
            collider.enabled = false;
            mainObject.SetActive(false);
            leftPart.gameObject.SetActive(true);
            rightPart.gameObject.SetActive(true);

            ForceCuttedOBjects(numberOfPiecesToForce);
            OnAnyCut?.Invoke();

            //coinManager.GetCoin(10);
        }
    }
    private void ForceCuttedOBjects(int amount)
    {
        if (amount == 0) return;

        for (int i = 0; i < amount; i++)
        {
            var rb = rigidbodies[i];

            var force = i == 0 ? new Vector3(+300, 0, 0) : new Vector3(-300, 0, 0);

            rb.AddForce(force + transform.GetChild(i + 1).transform.localPosition);
        }
    }
}
