// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float max_time = 1; //Esse valor pode ser substituído por uma fórmula que varia o spawn de acordo com o nível ou decair de forma escalar
    private float timer = 0;
    public GameObject obstacle;
    public float large;
    public float width;
    public float pontuacao;

    void Start()
    {
        GameObject new_obstacle = Instantiate(obstacle);
        new_obstacle.transform.position = transform.position + new Vector3(Random.Range(-width, width), 0, 0);
    }

    void Update()
    {
        //MUDAR -> Criar um objeto para cada tag e instanciar isso dentro do objeto, depois basta mudar o nome do objeto dentro do Instantiate
        //Criar uma lista com cada um dos objetos e depois basta incrementar o index da lista.
        // if(tag == 0) {//Para varia o spawn,cada tag tem um max_time e uma velocidade
        //     max_time_0 = ;
        //     velocidade = ;
        //     max_time = max_time_0;
        //     pontos = ;
        // }else if(tag == 1){
        //     max_time_0 = ;
        //     velocidade = ;
        //     max_time = max_time_0;
        //     pontos = ;
        // }else if(tag == 2){
        //     max_time_0 = ;
        //     velocidade = ;
        //     max_time = max_time_0;
        //     pontos = ;
        // }

        if(timer > max_time){ //Se o tempo limite do "nível" for atingido, um novo objeto é criado
            //isso seria feito com um parâmetro utilizado na fórmula que varia de acordo com a tag
            GameObject new_obstacle = Instantiate(obstacle); 
            new_obstacle.transform.position = transform.position + new Vector3(Random.Range(-width, width), 0, 0);
            Destroy(new_obstacle, 10);  //Destrói o objeto depois de 10 segundos que um novo for criado
            max_time = 0.9f * max_time;  //Diminui o intervalo de tempo conforme novos obstáculos forem gerados
            // if(max_time < max_time_0/2.0f){
                // tag++; //Se o novo max_timer for menor que metade (ajuste) do original, um novo obstáculo passa a surgir
            // }
            // pontuacao += pontos;
            timer = 0; //Zera o timer
        }
        timer += Time.deltaTime; //Incremento do tempo
    }
}