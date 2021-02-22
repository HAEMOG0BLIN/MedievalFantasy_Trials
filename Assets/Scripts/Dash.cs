using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashAmount;

    [SerializeField] private LayerMask dashLayerMask;

    private PlayerController pc;
    private Rigidbody rb;

    private void Awake()
    {
        pc = GetComponentInParent<PlayerController>();
        rb = pc.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(pc.isSpaceDown)
        {
            Vector3 dashPosition = pc.gameObject.transform.position + rb.velocity.normalized * dashAmount;

            if (Physics.Raycast(pc.gameObject.transform.position, rb.velocity.normalized, out RaycastHit hit, dashAmount, dashLayerMask))
            {
                dashPosition = hit.point;
            }

            rb.MovePosition(dashPosition);

            pc.isSpaceDown = false;
        }
    }
}
