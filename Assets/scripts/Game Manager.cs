using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    void Start()
    {
        // spawner.obstacle = new actual_stage[stage_index][obstacle_index]
        // GameObject[][] actual_stage = new GameObject[3][];
        // actual_stage[0] = new GameObject[3] {nuvem_1_0, nuvem_1_1, nuvem_3_0};
        // actual_stage[1] = new GameObject[3] {meteoro_1_0, meteoro_2_0, meteoro_3_0};
        // actual_stage[2] = new GameObject[3] {satelite_1, satelite_2, satelite_3};
    
        // extras = new GameObject[2] {balao_1, alien};
    }

    void Update()
    {
        // if(spawner.max_time < spawner.max_time_0/2.0f){
        //     obstacle_index++;
        //     if(obstacle_index > 2){
        //         stage_index++;
        //     }
        //     spawner.obstacle = new actual_stage[stage_index][obstacle_index];
        // }
    }
}
