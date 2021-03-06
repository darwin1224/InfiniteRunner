using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaScript : MonoBehaviour
{
    public GameObject shuriken;
    public float moveSpeed = 5f;
    private float cameraY;
    private bool attackedPlayer;
    // Start is called before the first frame update
    void Start()
    {
        cameraY = Camera.main.transform.position.y - 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Deactivate();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.y -= moveSpeed * Time.deltaTime;
        transform.position = temp;

        if (transform.position.y < 0)
        {
            if (!attackedPlayer)
            {
                attackedPlayer = true;
                Instantiate(shuriken, transform.position, Quaternion.identity);
            }
        }
    }

    void Deactivate()
    {
        if (transform.position.y < cameraY)
        {
            gameObject.SetActive(false);
        }
    }
}
