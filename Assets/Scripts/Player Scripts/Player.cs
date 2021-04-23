﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator anim;
    private bool onLeft, onRight;
    private bool jumped;

    private void Awake()
    {
        GameObject.Find("JumpBtn").GetComponent<Button>().onClick.AddListener(Jump);
        anim = GetComponent<Animator>();

        onRight = true;
        onLeft = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!jumped)
        {
            if (onRight)
            {
                anim.Play("RunRight");
            }
            else
            {
                anim.Play("RunLeft");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onRight)
            {
                anim.Play("JumpLeft");
            }
            else
            {
                anim.Play("JumpRight");
            }
            jumped = true;
        }
    }

    public void Jump()
    {
        if (onRight)
        {
            anim.Play("JumpLeft");
        }
        else
        {
            anim.Play("JumpRight");
        }
        jumped = true;
    }

    void OnLeft()
    {
        onLeft = true;
        onRight = false;
        jumped = false;
    }

    void OnRight()
    {
        onLeft = false;
        onRight = true;
        jumped = false;
    }
}