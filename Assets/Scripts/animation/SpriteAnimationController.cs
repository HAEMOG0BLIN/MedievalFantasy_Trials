using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimationController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] idle;
    public Sprite[] run;
    public Sprite[] walk;
    public Sprite[] attack;

    public float frameRate;

    bool isShiftDown = false;
    bool hasAttacked = false;

    private void Start()
    {
        StartCoroutine(Idle());
    }

    private void Update()
    {
        IsWASDBeingUsed();

        if (Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();
            StartCoroutine(Attack());
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isShiftDown = true;
        }
        else isShiftDown = false;
    }

    public void IsWASDBeingUsed()
    {
        if (isShiftDown)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                StopAllCoroutines();
                StartCoroutine(Run());
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                StopAllCoroutines();
                StartCoroutine(Walk());
            }
        }


        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetMouseButtonUp(0))
        {
            StopAllCoroutines();
            StartCoroutine(Idle());
        }
    }

    IEnumerator Run()
    {
        int i = 0;

        while (i < run.Length)
        {
            spriteRenderer.sprite = run[i];
            i++;

            yield return new WaitForSeconds(frameRate);
            yield return 0;
        }

        StartCoroutine(Run());
    }

    IEnumerator Walk()
    {
        int i = 0;

        while (i < walk.Length)
        {
            spriteRenderer.sprite = walk[i];
            i++;

            yield return new WaitForSeconds(frameRate);
            yield return 0;
        }

        StartCoroutine(Walk());
    }

    IEnumerator Attack()
    {
        int i = 0;

        while (i < attack.Length)
        {
            spriteRenderer.sprite = attack[i];
            i++;

            yield return new WaitForSeconds(frameRate);
            yield return 0;
        }

        IsWASDBeingUsed();
    }

    IEnumerator Idle()
    {
        int i = 0;

        while (i < idle.Length)
        {
            spriteRenderer.sprite = idle[i];
            i++;

            yield return new WaitForSeconds(frameRate);
            yield return 0;
        }

        StartCoroutine(Idle());
    }
}
