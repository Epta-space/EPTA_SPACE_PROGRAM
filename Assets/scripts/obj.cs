using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj : MonoBehaviour
{
    // Referente á declaração de prefabs
    public GameObject alien;
    public GameObject balao_1;
    public GameObject meteoro_1_0;
    public GameObject meteoro_2_0;
    public GameObject meteoro_3_0;
    public GameObject nuvem_1_0;
    public GameObject nuvem_1_1;
    public GameObject nuvem_3_0;
    public GameObject satelite_3;
    public GameObject satelite_1;
    public GameObject satelite_2;

    // Referente ao script game manager
    private GameObject Game_Manager;

    // Matrix para obstaculos
    private GameObject[][] actual_stage;
    public List<int> stage_length_list;
    
    // Start is called before the first frame update
    void Start()
    {
        // Geting game manager from tag in scene
        Game_Manager = GameObject.FindWithTag("Game_manager");
        
        // Declaring the obstacle matrix
        actual_stage = new GameObject[3][];
        
        actual_stage[0] = new GameObject[4];
        actual_stage[0][0] = nuvem_1_0;
        actual_stage[0][1] = nuvem_1_1;
        actual_stage[0][2] = nuvem_3_0;
        actual_stage[0][3] = balao_1;

        actual_stage[1] = new GameObject[3];
        actual_stage[1][0] = meteoro_1_0;
        actual_stage[1][1] = meteoro_2_0;
        actual_stage[1][2] = meteoro_3_0;

        actual_stage[2] = new GameObject[4];
        actual_stage[2][0] = satelite_1;
        actual_stage[2][1] = satelite_2;
        actual_stage[2][2] = satelite_3;
        actual_stage[2][3] = alien;

        // actual_stage[2].Length;
        stage_length_list.Add(4);
        stage_length_list.Add(3);
        stage_length_list.Add(4);
    }

    public GameObject Get_Obstacle(){
        
        int stage_index = Game_Manager.GetComponent<Game_Manager>().Get_phase();
        int stage_length = stage_length_list[stage_index];
        int obstacle_index = (int)Random.Range(0, stage_length);

        return actual_stage[stage_index][obstacle_index];
    }
}
