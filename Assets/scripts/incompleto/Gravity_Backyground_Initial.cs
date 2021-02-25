using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Backyground_Initial : MonoBehaviour
{

    void Start(){

        Start_fall();

    }

    void Start_fall()
    {
        Component[] elementos;

        elementos = GetComponentsInChildren<Rigidbody2D>();

        foreach (Rigidbody2D elemento in elementos)
        {
            elemento.gravityScale = 1;
        }
    }
}
