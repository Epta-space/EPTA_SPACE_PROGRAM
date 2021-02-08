using System.Collections.Generic;
using UnityEngine;

public class Object_selector : MonoBehaviour
{

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
    private GameObject Game_manager;
    private static GameObject obstacle;
    private GameObject[][] actual_stage;
    private int stage_index;
    private int obstacle_index;
    private List<int> stage_length_list = new List<int>{4,3,4};
    private int stage_length;

    void Start()
    {
        // Acha o script game manager via tag
        Game_manager = GameObject.FindWithTag("Game_manager");

    }

    public GameObject Get_Obstacle(){
        stage_index = Game_manager.GetComponent<Game_Manager>().Get_phase();
        
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

        stage_length = stage_length_list[stage_index-2];
        obstacle_index = (int)Random.Range(0, stage_length);
        obstacle = actual_stage[stage_index-2][obstacle_index];
        return obstacle;
    }

}