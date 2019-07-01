using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapWeapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject arrowPrefab;
    public float arrowFreq;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("Shoot", 0f, arrowFreq);
    }

    void Shoot()
    {
        //prefab shooting
        Instantiate(arrowPrefab, FirePoint.position, FirePoint.rotation);

    }
}
