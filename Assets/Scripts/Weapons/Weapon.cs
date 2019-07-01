using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject arrowPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("HI");
            Shoot();
        }
    }

    void Shoot(){

        //prefab shooting
        Instantiate(arrowPrefab, FirePoint.position, FirePoint.rotation);

    }
}
