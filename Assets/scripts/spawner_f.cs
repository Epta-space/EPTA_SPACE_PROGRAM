using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_f : MonoBehaviour {
    private int phase;

    // private int[] spawn_groups = new int[1]{
        // {0 , } 

        // GameObject[][] actual_stage = new GameObject[3][];
        //         actual_stage[0] = new GameObject[4] {nuvem_1_0, nuvem_1_1, nuvem_3_0, balao_1};
        //         actual_stage[1] = new GameObject[3] {meteoro_1_0, meteoro_2_0, meteoro_3_0};
        //         actual_stage[2] = new GameObject[4] {satelite_1, satelite_2, satelite_3, alien};
    // };



    void Start() {
        
    }

    void Update()
    {
        // Get current phase 
        phase = this.gameObject.GetComponent<game_manager_f>().Get_phase();

        // spawn( spawn_groups[phase][aleatorio()][3][0] , spawn_groups[phase][aleatorio()][3][1])

        // Debuging command
        Debug.Log(this.gameObject.GetComponent<game_manager_f>().Get_phase_time()); 
    }
}