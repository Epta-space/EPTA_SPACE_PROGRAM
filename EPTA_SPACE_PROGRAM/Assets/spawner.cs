using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float max_time; //Esse valor pode ser substituído por uma fórmula que varia o spawn de acordo com o nível ou decair de forma escalar
    public float max_time_0;
    private float timer;
    public GameObject obstacle;
    public float large;
    public float width;
    public float pontuacao;
    public float pontos;
    public GameObject alien;
    public GameObject balao_1;
    public GameObject meteoro_1_0;
    public GameObject meteoro_2_0;
    public GameObject meteoro_3_0;
    public GameObject nuvem_1_0;
    public GameObject nuvem_1_1;
    public GameObject nuvem_1_2;
    public GameObject nuvem_11_0;
    public GameObject nuvem_3_0;
    public GameObject satelite_3;
    public GameObject satelite_1;
    public GameObject satelite_2;
    public GameObject[] obstaculos;
    public int index;

    void Start()
    {
        GameObject new_obstacle = Instantiate(obstacle);
        new_obstacle.transform.position = transform.position + new Vector3(Random.Range(-width, width), 0, 0);
        obstaculos = new GameObject[] {alien, balao_1, meteoro_1_0, meteoro_2_0, meteoro_3_0, nuvem_1_0, nuvem_1_1, nuvem_1_2, nuvem_3_0, nuvem_11_0, satelite_3, satelite_1, satelite_2};
    }

    void Update()
    {
        obstacle = obstaculos[index];
        if(timer > max_time){ //Se o tempo limite do "nível" for atingido, um novo objeto é criado
            //isso seria feito com um parâmetro utilizado na fórmula que varia de acordo com a tag
            GameObject new_obstacle = Instantiate(obstacle); 
            new_obstacle.transform.position = transform.position + new Vector3(Random.Range(-width, width), 0, 0);
            Destroy(new_obstacle, 10);  //Destrói o objeto depois de 10 segundos que um novo for criado
            max_time = 0.9f * max_time;  //Diminui o intervalo de tempo conforme novos obstáculos forem gerados
            if(max_time < max_time_0/2.0f){
                index++; //Se o novo max_timer for menor que metade (ajuste) do original, um novo obstáculo passa a surgir
            }
            pontuacao += pontos;
            timer = 0; //Zera o timer
        }
        timer += Time.deltaTime; //Incremento do tempo
    }
}