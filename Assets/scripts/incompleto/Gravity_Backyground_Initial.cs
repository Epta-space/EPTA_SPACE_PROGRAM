using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Backyground_Initial : MonoBehaviour
{

    private GameObject game_manager;

    void Start(){

        game_manager = GameObject.FindWithTag("Game_manager");

    }

    public void Start_fall()
    {
        Component[] elementos;

        elementos = GetComponentsInChildren<Rigidbody2D>();

        foreach (Rigidbody2D elemento in elementos)
        {
            elemento.gravityScale = 3;
        }
    }
}
