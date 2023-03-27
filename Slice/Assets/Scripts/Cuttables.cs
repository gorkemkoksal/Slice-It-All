using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Cuttables : MonoBehaviour
{
    [SerializeField] private Transform leftPart;
    [SerializeField] private Transform rightPart;
    [SerializeField] private GameObject mainObject;
    [SerializeField] private bool isLego;
    [SerializeField] private bool forceAllCuttedObjects;

    private bool isCutted;

    private Material legoMaterial;

    private void Start()
    {
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

            mainObject.SetActive(false);
            leftPart.gameObject.SetActive(true);
            rightPart.gameObject.SetActive(true);

            if (forceAllCuttedObjects) ForceCuttedOBjects(2);
            else ForceCuttedOBjects(1);

        }
    }
    private void ForceCuttedOBjects(int amount)
    {
        for (int i = 1; i <= amount; i++)
        {
            var rb = transform.GetChild(i).gameObject.GetComponent<Rigidbody>();

            var force = i == 1 ? new Vector3(+100, 0, 0) : new Vector3(-100, 0, 0);

            rb.AddForce(force + transform.GetChild(i).transform.localPosition);
        }
    }
}
