using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gravity : MonoBehaviour
{

    Rigidbody2D rb;
    public int mass = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = mass;


    }
   

}