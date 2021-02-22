using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage;
    public float range;

    public Camera cam;
    public LayerMask ignoreMask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
        Shoot();
        }
    }

    public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, ignoreMask))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
