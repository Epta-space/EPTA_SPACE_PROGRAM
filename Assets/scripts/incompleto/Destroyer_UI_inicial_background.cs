using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Destroyer_UI_Initial_background : MonoBehaviour
{  // Start is called before the first frame update
    public dynamic game_manager;

    void Start()
    {   
        int fase = game_manager.GetComponent<Game_Manager>().Get_phase();
        game_manager = GameObject.FindWithTag("GameManager");

    }

    void Update()
    {
        float time = game_manager.GetComponent<Game_Manager>().Get_phase_time();

        if (time > 10)
        {
        Destroy(this);
        }
    
    }  
}