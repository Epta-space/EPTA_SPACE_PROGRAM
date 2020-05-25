using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movimentação : MonoBehaviour
{

    public Rigidbody2D rb;
    public float velocity;
    private float screenWidth;
    private Vector3 localScreenWidth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > screenWidth / 2)
            {
                if (transform.position.x <= screenWidth / 2)
                {
                    rb.velocity = Vector2.right * velocity;
                }
            }
            else if (Input.GetTouch(0).position.x < screenWidth / 2)
            {
                if (transform.position.x >= -screenWidth / 2)
                {
                    rb.velocity = Vector2.left * velocity;
                }
            }
        }

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
