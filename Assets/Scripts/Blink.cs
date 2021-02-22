using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public float blinkAmount;

    private PlayerController pc;
    private Rigidbody rb;

    private void Awake()
    {
        pc = GetComponentInParent<PlayerController>();
        rb = pc.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (pc.isSpaceDown)
        {
            rb.MovePosition(pc.gameObject.transform.position + rb.velocity.normalized * blinkAmount);

            pc.isSpaceDown = false;
        }
    }
}
