using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator anim;
    private bool onLeft, onRight;
    private bool jumped;

    [SerializeField]
    AudioSource audioKill, audioJump;
    [SerializeField]
    private AudioClip deadSound;
    private bool isAlive = true;

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
        if (isAlive)
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
                audioJump.Play();
            }
        }
    }

    public void Jump()
    {
        if (isAlive)
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
            audioJump.Play();
        }
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

    void PlayerDied()
    {
        audioKill.clip = deadSound;
        audioKill.Play();

        if (transform.position.x > 0)
        {
            anim.Play("PlayerDiedRight");
        }
        else
        {
            anim.Play("PlayerDiedLeft");
        }

        GameplayController.instance.GameOver();

        Time.timeScale = 0f;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (jumped)
        {
            if (target.tag == "Enemy")
            {
                target.gameObject.SetActive(false);
                audioKill.Play();
            }
        }
        else
        {
            if (target.tag == "Enemy")
            {
                PlayerDied();
            }
        }

        if (target.tag == "EnemyTree")
        {
            PlayerDied();
        }
    }
}
