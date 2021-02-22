using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public SpriteRenderer spriteRenderer;

    public bool isSpaceDown;

    public float x, z;
    public float speed;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        XInput();
        ZInput();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpaceDown = true;
        }

        rb.velocity = new Vector3(x, 0, z).normalized * speed;
    }

    private void LateUpdate()
    {
        FlipSprite();
    }

    void FlipSprite()
    {
        if (x < 0f)
        {
            spriteRenderer.flipX = true;
        }
        else spriteRenderer.flipX = false;
    }

    public void XInput()
    {
        x = Input.GetAxisRaw("Horizontal");
    }

    public void ZInput()
    {
        z = Input.GetAxisRaw("Vertical");
    }
}
