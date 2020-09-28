using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public GameObject Player;

    public GameObject obstacle;

    //Variáveis para dimensão da tela
    private float width;
    private Vector3 localScreenWidth;

    //Variáveis para estabelecer range seguro para geração de obstáculos
    private float random_range_a;
    private float random_range_b;

    private float player_height;

    private float safeDistance = 0;

    private float tempo_relativo;
    private float tempo_para_spawn;

    public GameObject objeto1;
    public GameObject objeto2;

    //Lista com os últimos objetos criados
    private GameObject[] lastObstacles;

    public Object_Selector objselector;

    GameObject createObstacle(){
        obstacle = objselector.Get_Obstacle();

        GameObject new_obstacle = Instantiate(obstacle);
        new_obstacle.transform.position = transform.position + new Vector3(UnityEngine.Random.Range(-random_range_a, random_range_b), 0, 0);

        tempo_relativo = Game_Manager.time;

        return new_obstacle;
    }   

    float take_height(GameObject obj){
        RectTransform rt = (RectTransform)Player.transform;
        float player_height = rt.rect.height;

        return player_height;
    }

    void Start() {
        
        objeto1 = objselector.Get_Obstacle();
        objeto2 = objselector.Get_Obstacle();

        lastObstacles = new GameObject[2] {objeto1, objeto2};

        localScreenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        random_range_a = localScreenWidth.x - (0.3f * localScreenWidth.x);
        random_range_b = localScreenWidth.x + (0.2f * localScreenWidth.x);

        // GameObject[] lastObstacles ;
        lastObstacles[0] = lastObstacles[1];
        lastObstacles[1] = createObstacle();

        float player_height = take_height(Player);
        float safeDistance = player_height;
        safeDistance *= 1.1f;
    }

    void Update()
    {
        objeto1 = lastObstacles[0];
        objeto2 = lastObstacles[1];

        //! NullReferenceException: Object reference not set to an instance of an object
        tempo_para_spawn = (safeDistance - (objeto1.transform.position.y - objeto2.transform.position.y)) / (objeto1.GetComponent<move>().Get_velocity() - objeto2.GetComponent<move>().Get_velocity());

        
        if(Game_Manager.time - tempo_relativo >= tempo_para_spawn){
            lastObstacles[0] = lastObstacles[1];
            lastObstacles[1] = createObstacle();
        }
    }
} 