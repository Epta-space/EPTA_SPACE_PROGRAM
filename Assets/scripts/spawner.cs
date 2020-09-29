using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public GameObject Player;

    private GameObject obstacle;

    //Variáveis para dimensão da tela
    private float width;
    private Vector3 localScreenSize;

    //Variáveis para estabelecer range seguro para geração de obstáculos
    private float random_range_a;
    private float random_range_b;

    private float player_height;

    private float safeDistance = 0;

    private float tempo_relativo;
    private float tempo_para_spawn;

    private GameObject objeto1;
    private GameObject objeto2;

    //Lista com os últimos objetos criados
    private GameObject[] lastObstacles;

    public Object_Selector objselector;

    public GameObject GameSpawner;

    private float Tx;
    private float Ty;

    GameObject createObstacle(){
        obstacle = objselector.Get_Obstacle();

        GameObject new_obstacle = Instantiate(obstacle);
        new_obstacle.transform.position = transform.position + new Vector3(UnityEngine.Random.Range(-random_range_a, random_range_b), 0, 0);

        tempo_relativo = Game_Manager.time;

        return new_obstacle;
    }   

    float take_height(GameObject obj){
        // RectTransform rt = (RectTransform)Player.transform;   
        // float player_height = rt.rect.height;
        player_height = 1;
        return player_height;
    }

    void Start() {
        lastObstacles = new GameObject[2];

        lastObstacles[0] = objselector.Get_Obstacle();
        lastObstacles[1] = objselector.Get_Obstacle();

        localScreenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        random_range_a = localScreenSize.x - (0.1f * localScreenSize.x);
        random_range_b = localScreenSize.x;// + (0.2f * localScreenSize.x);

        // lastObstacles[0] = lastObstacles[1];
        // lastObstacles[1] = createObstacle();

        float player_height = take_height(Player);
        float safeDistance = player_height;
        safeDistance *= 1.1f;

        objeto1 = lastObstacles[0];
        objeto2 = lastObstacles[1];
    }

    void RightTimeToSpawn(){
        Tx = Math.Abs(2* (0.6f * localScreenSize.y)/(objeto1.GetComponent<move>().Get_velocity()));
        Ty = Math.Abs(2*((0.6f * localScreenSize.y) - safeDistance)/(objeto2.GetComponent<move>().Get_velocity()));
        tempo_para_spawn = (Tx - Ty) * 4;
    }

    void Update()
    {
        objeto1 = lastObstacles[0];
        objeto2 = lastObstacles[1];

        // print("Velocidade do objeto1: " + objeto1.GetComponent<move>().Get_velocity() +
        //       "\nVelocidade do objeto2: " + objeto2.GetComponent<move>().Get_velocity() + 
        //       "\nPosição do objeto1: " + objeto1.transform.position.y + 
        //       "\nPosição do objeto2: " + objeto2.transform.position.y
        //     );
    

        //!
        RightTimeToSpawn();
        print("Tempo para spawn: " + tempo_para_spawn);
        print("Tempo atual: " + (Game_Manager.time - tempo_relativo));
        if(Game_Manager.time - tempo_relativo >= tempo_para_spawn){
            lastObstacles[0] = lastObstacles[1];
            lastObstacles[1] = createObstacle();
        }
    }
} 