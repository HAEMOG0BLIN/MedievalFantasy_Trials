using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempCrosshair : Gun
{
    public Image tempCrosshair;

    private void Start()
    {
        range = this.GetComponent<Gun>().range;
    }

    new void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, range, ignoreMask))
        {
            tempCrosshair.transform.position = Camera.main.WorldToScreenPoint(hit.point);
        }
    }
}
