using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;

    private float timer;
    public float score;

    public float max_time; //Esse valor pode ser substituído por uma fórmula que varia o spawn de acordo com o nível ou decair de forma escalar
    public float max_time_0;
    public float velocidade;
    public float pontos;

    public float width;

    public GameObject alien ;//{
        // set{
        // max_time_0 = 0;
        // velocidade = 0;
        // max_time = max_time_0;
        // pontos = 5;
        // }
    //}

    public GameObject balao_1;//{
        // set{
        // max_time_0 = 0;
        // velocidade = 0;
        // max_time = max_time_0;
      // pontos = 5;
        // }
    //}

    public GameObject meteoro_1_0;//{
        // set{
        // max_time_0 = 0;
        // velocidade = 0;
        // max_time = max_time_0;
      // pontos = 5;
        // }
    //}

    public GameObject meteoro_2_0;//{
        // set{
        // max_time_0 = 0;
        // velocidade = 0;
        // max_time = max_time_0;
      // pontos = 5;
        // }
    //}

    public GameObject meteoro_3_0;//{
        // set{
        // max_time_0 = 0;
        // velocidade = 0;
        // max_time = max_time_0;
      // pontos = 5;
        // }
    //}

    public GameObject nuvem_1_0;//{
        // set{
        // max_time_0 = 0;
        // velocidade = 0;
        // max_time = max_time_0;
      // pontos = 5;
        // }
    //}

    public GameObject nuvem_1_1;//{
        // set{
        // max_time_0 = 0;
        // velocidade = 0;
        // max_time = max_time_0;
      // pontos = 5;
        // }
    //}

    public GameObject nuvem_3_0;//{
        // set{
        // max_time_0 = 0;
        // velocidade = 0;
        // max_time = max_time_0;
      // pontos = 5;
        // }
    //}

    public GameObject satelite_3;//{
        // set{
        // max_time_0 = 0;
        // velocidade = 0;
        // max_time = max_time_0;
      // pontos = 5;
        // }
    //}

    public GameObject satelite_1;//{
        // set{
        // max_time_0 = 0;
        // velocidade = 0;
        // max_time = max_time_0;
      // pontos = 5;
        // }
    //}

    public GameObject satelite_2;//{
        // set{
        // max_time_0 = 0;
        // velocidade = 0;
        // max_time = max_time_0;
      // pontos = 5;
        // }
    //}

    public GameObject[] extras;
    public GameObject[] actual_stage;

    public int stage_index;
    public int obstacle_index;

    void Start()
    {
        GameObject new_obstacle = Instantiate(obstacle);
        new_obstacle.transform.position = transform.position + new Vector3(Random.Range(-width, width), 0, 0);

        GameObject[][] actual_stage = new GameObject[3][];
        actual_stage[0] = new GameObject[3] {nuvem_1_0, nuvem_1_1, nuvem_3_0};
        actual_stage[1] = new GameObject[3] {meteoro_1_0, meteoro_2_0, meteoro_3_0};
        actual_stage[2] = new GameObject[3] {satelite_1, satelite_2, satelite_3};
    
        extras = new GameObject[2] {balao_1, alien};
    }

    void Update()
    {
        // obstacle = actual_stage[stage_index][obstacle_index];
        if(timer > max_time){ //Se o tempo limite do "nível" for atingido, um novo objeto é criado
            //isso seria feito com um parâmetro utilizado na fórmula que varia de acordo com a tag
            GameObject new_obstacle = Instantiate(obstacle); 
            new_obstacle.transform.position = transform.position + new Vector3(Random.Range(-width, width), 0, 0);
            Destroy(new_obstacle, 10);  //Destrói o objeto depois de 10 segundos que um novo for criado
            max_time = 0.9f * max_time;  //Diminui o intervalo de tempo conforme novos obstáculos forem gerados
            if(max_time < max_time_0/2.0f){
                obstacle_index++; //Se o novo max_timer for menor que metade (ajuste) do original, um novo obstáculo passa a surgir
                if(obstacle_index > 2){
                    stage_index++;
                }
            }
            timer = 0; //Zera o timer
        }
        score += pontos;
        timer += Time.deltaTime; //Incremento do tempo
    }
}