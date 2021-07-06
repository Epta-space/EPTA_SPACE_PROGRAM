using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class spawner : MonoBehaviour {

    // Game Objects importantes
    public GameObject objselector;
    private GameObject Game_manager;

    // Dados globais importantes
    private float screen_width;
    private int stage;



    void Start() {

        objselector = GameObject.FindWithTag("Object_selector");
        Game_manager = GameObject.FindWithTag("Game_manager");

        // Getting the screen width 
        screen_width = Camera.main.orthographicSize * Screen.width / Screen.height - Camera.main.transform.position.x;

        // Chamada regular do SpawnerManager
        InvokeRepeating("ObstacleCreationManager",1f,1f);
    }

    // Manager of spawn methods
    private void ObstacleCreationManager(){
        // Pega a fase atual
        stage = Game_manager.GetComponent<Game_Manager>().Get_phase();

        // Define o método de spawn de acordo com a fase
        switch(stage){
        case 1:
            // Spawn específico da fase 1
            Spawn_nuvens();
            break;
        case 2:
            // Primeiro spawn criado
            // Spawn_método_simples();
            //  Necessário criar novas fases para configurar o switch
            Spawn_satélites();
            break;
        case 3:
            Spawn_meteoros();
            break;
        default:
            break;
        }

    }

    private void CreateObstacle(float x_coordinate, float y_velocity, float x_velocity, float rotation){
        // Calculate location of spawn
        float spawn_coordinate = x_coordinate * screen_width;

        // Get obstacle sprite for this phase and create it
        GameObject new_obstacle = Instantiate(objselector.GetComponent<Object_selector >().Get_Obstacle());

        Rigidbody2D rb = new_obstacle.GetComponent<Rigidbody2D>();

        // Transform position of the object created
        new_obstacle.transform.position = transform.position + new Vector3(spawn_coordinate, 0, 0);
        
        rb.angularVelocity= rotation;

        // Transform vertical velocity of object created
        new_obstacle.GetComponent<move>().SetSpeed(y_velocity, x_velocity);
    }

    // MÉTODOS DE SPAWN  ##################################################################################
    private void Spawn_método_simples(){

        // Take current player location
        float player_float_x = Game_manager.GetComponent<Game_Manager>().Get_player_x()/screen_width;

        // Calcula o local do player de 0 a 1
        float where_to_spawn = player_float_x;

        // Calcula fração atual do tempo da fase
        float velocity = Game_manager.GetComponent<Game_Manager>().Get_phase_fraction() * 5.0f + 3;

        // Cria obstáculo lá 
        CreateObstacle(where_to_spawn, velocity,0,0);
    }

    private void Spawn_nuvens(){
        // Contador para checar se a velocidade chegou no ponto de estabização:
        bool estabilizar = false;

        // // Take current player location
        // float player_float_x = Game_manager.GetComponent<Game_Manager>().Get_player_x()/screen_width;

        // // Calcula o local do player de 0 a 1
        // float where_to_spawn = UnityEngine.Random.Range(player_float_x * 0.9f, player_float_x * 1.1f);

        // // No caso das nuvens, é interessante fazer o contrário (quanto mais tempo passa, mas devagar ficam), pois no começo o foguete tem uma aceleração maior
        // // A partir de um ponto x, as nuvens devem vir com a mesma velocidade
        // float velocity = 9 / (Game_manager.GetComponent<Game_Manager>().Get_phase_fraction() + 1.5f) + 2;

         // Spawn em posição aleatória
        float where_to_spawn = UnityEngine.Random.Range(-1.0f,1.0f);

        // Calcula fração atual do tempo da fase
        // float velocity = 8 / (Game_manager.GetComponent<Game_Manager>().Get_phase_fraction() + 1.5f) + 1.5f;
        
        float velocity = 2f * Mathf.Exp(Game_manager.GetComponent<Game_Manager>().Get_phase_fraction()) + 1.5f  ;

        if(velocity <= 6){
            estabilizar = true;
        }

        if(estabilizar){
            velocity = 6;
        }

        // Cria obstáculo lá 
        CreateObstacle(where_to_spawn, velocity,0,0);
        Debug.Log(where_to_spawn);
    }

    private void Spawn_satélites(){
        bool estabilizar = false;

        float player_float_x = Game_manager.GetComponent<Game_Manager>().Get_player_x()/screen_width;

        float where_to_spawn = UnityEngine.Random.Range(player_float_x * 0.9f, player_float_x * 1.1f);

        float velocity = (Game_manager.GetComponent<Game_Manager>().Get_phase_fraction() * 1.5f) + 6;

        // Velocidade horizontal (velocidade de órbita, bem baixa)
        float rnd = UnityEngine.Random.Range(-1,2);
        float horizontal_velocity =  (int)rnd;
        horizontal_velocity = (horizontal_velocity * (3/2) * Game_manager.GetComponent<Game_Manager>().Get_phase_fraction()); // Reavaliar método de criação de obstáculos para aceitar a velocidade horizontal

        if(velocity <= 6){
            estabilizar = true;
        }

        if(estabilizar){
            velocity = 6;
        }

        // Cria obstáculo com ambas as velocidades  
        CreateObstacle(where_to_spawn, velocity, horizontal_velocity,0);
    }


    private void Spawn_meteoros(){

        // Sugestão:
        // Criar variações no tamanho, podendo ter meteoros muito grandes ou até mesmo muito pequenos
        // Os muito pequenos, ao invés de matar, podem desviar a trajetória do foguete, causar descontrole por um período ou tirar somente parte da vida
        // Podem ser spawnados mais de um obstáculo ao mesmo tempo

        bool estabilizar = false;

        float player_float_x = Game_manager.GetComponent<Game_Manager>().Get_player_x()/screen_width;

        float where_to_spawn = UnityEngine.Random.Range(player_float_x * 0.9f, player_float_x * 1.1f);

        float velocity = 2.5f * Mathf.Sqrt(Game_manager.GetComponent<Game_Manager>().Get_phase_fraction()) + 7.5f;

        float speedRotate = 30;

        // // Rotação dos meteóros
        // transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
        

        // Velocidade horizontal (velocidade de órbita, bem baixa)
        // float rnd = UnityEngine.Random.Range(-1,2);
        // float horizontal_velocity = (int)rnd;
        float horizontal_velocity = 0;

        // tem um ponto que fica invencível
        if(player_float_x>0.1){
            horizontal_velocity = -1;
        }
        else if(player_float_x < -0.1){
            horizontal_velocity = 1;
        }
        else{
            horizontal_velocity = 0;
        }

        horizontal_velocity = (horizontal_velocity * (3/2) * Game_manager.GetComponent<Game_Manager>().Get_phase_fraction()); // Reavaliar método de criação de obstáculos para aceitar a velocidade horizontal

        if(velocity <= 6){
            estabilizar = true;
        }

        if(estabilizar){
            velocity = 6;
        }

        // Cria obstáculo com ambas as velocidades  
        CreateObstacle(where_to_spawn, velocity, horizontal_velocity, speedRotate);
    }

}
