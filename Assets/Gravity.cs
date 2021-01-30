using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    void Start()
    {
        Component[] elementos;

        elementos = GetComponentsInChildren<Rigidbody2D>();

        foreach (Rigidbody2D elemento in elementos)
        {
            elemento.gravityScale = 1;
        }
    }
}
