using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_f : MonoBehaviour {
    private int phase;
    public GameObject spawn_group_0_0;
    public GameObject spawn_group_0_1;
    public GameObject spawn_group_0_2;

    private GameObject[][] spawn_groups = new GameObject[1][];

    
    // private int[] spawn_groups = new int[1]{
        // {0 , } 

        // GameObject[][] actual_stage = new GameObject[3][];
        //         actual_stage[0] = new GameObject[4] {nuvem_1_0, nuvem_1_1, nuvem_3_0, balao_1};
        //         actual_stage[1] = new GameObject[3] {meteoro_1_0, meteoro_2_0, meteoro_3_0};
        //         actual_stage[2] = new GameObject[4] {satelite_1, satelite_2, satelite_3, alien};
    // };



    void Start() {
        spawn_groups[0] = new GameObject[3]{spawn_group_0_0 , spawn_group_0_1 , spawn_group_0_2};
    }

    void Update()
    {
        // Get current phase 
        phase = this.gameObject.GetComponent<game_manager_f>().Get_phase();
        
        


        // Debuging command
        Debug.Log(this.gameObject.GetComponent<game_manager_f>().Get_player_x()); 
    }
}