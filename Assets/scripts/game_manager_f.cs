﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager_f : MonoBehaviour
{
    private float time_point;
    private int phase;
    
    // Defines the phase brake points in seconds 
    private float[] phase_plan = new float[3]{1.5f*60, 3.0f*60, 4.0f*60}; 
    
    void Start()
    {   
        // Register time when the game starts 
        time_point = Time.time;
        phase = 0;

    }

    // Update is called once per frame
    void Update()
    {
        // Phase Query
        if(Time.time > phase_plan[phase]){
            phase++;
            time_point = Time.time;
        }
        
    }

    // Function for other scripts to aces current phase
    public int Get_phase(){return phase;}
    
    // Function for other scripts to aces current phase time in seconds
    public float Get_phase_time(){return Time.time - time_point;}

    // Function for Getting time globall time
    public float Get_time(){return Time.time;}
}
