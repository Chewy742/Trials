using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    
    public Transform FirePoint;
    public GameObject arrowPrefab;
    public float fireRate;
    public float delay; 

    // Update is called once per frame
    void Start()
    {

        InvokeRepeating("Shoot", delay, fireRate);
     
    }

    void Shoot()
    {
        //prefab shooting
        Instantiate(arrowPrefab, FirePoint.position, FirePoint.rotation);

    }

}
