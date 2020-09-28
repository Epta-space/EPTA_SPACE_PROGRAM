using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour{

    public static int stage = 0;
    public static float time = 0;
    public float n = 1;

    void Start()
    {
        time += Time.deltaTime;
    }

    void Update()
    {
        time += Time.deltaTime;
        if(stage < 4){
            if(time >= 200 * n){
                stage++;
                n *= 1.5f;
            }
        }
    }
}
