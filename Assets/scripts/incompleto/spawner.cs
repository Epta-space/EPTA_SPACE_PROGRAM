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

        // Chamada do único método de spawn em existência
        Spawn_método_simples();

    }

    private void CreateObstacle(float x_coordinate, float y_velocity){
        // Calculate location of spawn
        float spawn_coordinate = x_coordinate * screen_width;

        // Get obstacle sprite for this phase and create it
        GameObject new_obstacle = Instantiate(objselector.GetComponent<Object_selector >().Get_Obstacle());

        // Transform position of the object created
        new_obstacle.transform.position = transform.position + new Vector3(spawn_coordinate, 0, 0);

        // Transform vertical velocity of object created
        new_obstacle.GetComponent<move>().SetSpeed(y_velocity);
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
        CreateObstacle(where_to_spawn, velocity);
    }
}
