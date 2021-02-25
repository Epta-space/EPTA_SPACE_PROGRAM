using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Initial_background_Destroyer : MonoBehaviour
{  // Start is called before the first frame update
    private GameObject manager_object;
    public float tempo_morte;

    void Start()
    {   
        manager_object = GameObject.FindWithTag("Game_manager");
 
    }

    void Update()
    {
        int fase = manager_object.GetComponent<Game_Manager>().Get_phase();       
        float time = manager_object.GetComponent<Game_Manager>().Get_phase_time();

        if (time > tempo_morte)
        {
            Destroy(this.gameObject);
        }
    
    }  
}
