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
    private GameObject camera;

    // Matrix para obstaculos
    private GameObject[][] actual_stage = new GameObject[3][];
    
    // Start is called before the first frame update
    public void Start()
    {
        // Geting game manager from tag in scene
        Game_Manager = GameObject.FindWithTag("Game_manager");
        camera = GameObject.FindWithTag("MainCamera");

        // Declarando a matrix de objetos
        actual_stage[0] = new GameObject[4]{nuvem_1_0, nuvem_1_1, nuvem_3_0, balao_1};
        actual_stage[1] = new GameObject[3]{meteoro_1_0, meteoro_2_0, meteoro_3_0};
        actual_stage[2] = new GameObject[4]{satelite_1, satelite_2, satelite_3, alien};
    }

    public GameObject Get_Obstacle(){

        int stage_index = Game_Manager.GetComponent<Game_Manager>().Get_phase();
        int stage_length = actual_stage[stage_index].Length;
        int obstacle_index = (int)Random.Range(0, stage_length);

        return actual_stage[stage_index][obstacle_index];
    }
}
