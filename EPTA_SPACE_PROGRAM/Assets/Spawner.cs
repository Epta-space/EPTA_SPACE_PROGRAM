using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float max_time = 1; //Esse valor pode ser substituído por uma fórmula que varia o spawn de acordo com o nível
    private float timer = 0;
    public GameObject obstacle;
    public float large;
    public float width;

    void Start()
    {
        GameObject new_obstacle = Instantiate(obstacle);
        new_obstacle.transform.position = transform.position + new Vector3(Random.Range(-width, width), 0, 0);
    }

    void Update()
    {
        if(timer > max_time) //Se o tempo limite do nível for atingido, um novo objeto é criado
        {
            //Para varia o spawn, pode-se adcionar uma tag aos objetos, fazendo com que cada um tenha um max_time e uma velocidade
            //isso seria feito com um parâmetro utilizado na fórmula que varia de acordo com a tag
            GameObject new_obstacle = Instantiate(obstacle);
            new_obstacle.transform.position = transform.position + new Vector3(Random.Range(-width, width), 0, 0);
            Destroy(new_obstacle, 10); //Destroi o objeto depois de 10 segundos que um novo for criado
            timer = 0; //Zera o timer
        }
        timer += Time.deltaTime; //Incremento do tempo
    }
}
