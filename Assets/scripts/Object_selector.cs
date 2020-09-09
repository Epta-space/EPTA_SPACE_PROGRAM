using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
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

    public GameObject obstacle;

    public GameObject[] extras;
    public GameObject[] actual_stage;

    // private int stage_index =  GameManager.stage;
    private int stage_index = 0;

    public int obstacle_index = 0;
    private int stage_length = 0;

    void Start()
    {
        GameObject[][] actual_stage = new GameObject[3][];

        actual_stage[0] = new GameObject[4] {nuvem_1_0, nuvem_1_1, nuvem_3_0, balao_1};
        actual_stage[1] = new GameObject[3] {meteoro_1_0, meteoro_2_0, meteoro_3_0};
        actual_stage[2] = new GameObject[4] {satelite_1, satelite_2, satelite_3, alien};
        
        // stage_length = (actual_stage[stage_index]).Count;
        // obstacle_index = Random.Range(0, stage_length);

        GameObject obstacle = actual_stage[stage_index][obstacle_index];
    }

    void Update()
    {

    }
}
