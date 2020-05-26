using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movimentação : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private float screenWidth;
    private Vector3 localScreenWidth;
    private float move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        
    }

    void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2 (move * speed, rb.velocity.y);

        localScreenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        if (transform.position.x >= localScreenWidth.x + 0.06 * localScreenWidth.x)
        {

            transform.position = new Vector3(-transform.position.x + 0.06f * localScreenWidth.x, transform.position.y, transform.position.z);

        }
        else if (transform.position.x <= -(localScreenWidth.x + 0.06 * localScreenWidth.x))
        {

            transform.position = new Vector3(-transform.position.x - 0.06f * localScreenWidth.x, transform.position.y, transform.position.z);
        }
    }
}
