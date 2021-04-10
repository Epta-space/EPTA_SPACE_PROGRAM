using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_colide_handler : MonoBehaviour
{
    // Vetor de obstáculos
    private List<string> obstacle_list = new List<string>{"Nuv_1_0", "Nuv_1_1", "Nuv_3_0", "Balao"  , "Alien"  , "Met_1", "Met_2"  , "Met_3"  , "Sat_1", "Sat_2"  , "Sat_3"};

    // Game manager reference
    private GameObject Game_manager;

    // Função chamada no início do jogo
    void Start()
    {
        // Acha o script game manager via tag
        Game_manager = GameObject.FindWithTag("Game_manager");
        
    }

    // No momento em que ocorre a colisão ele chama essa função
    void OnCollisionEnter2D(Collision2D objeto_alvo)
    {
        // Chama o gerenciador de colisões
        ColisorHandler(objeto_alvo.gameObject.tag);
    }

    private void ColisorHandler(string colidido){
        if(obstacle_list.Contains(colidido)){

            // Chama a função de fim de jogo
            Game_manager.GetComponent<Game_Manager>().Terminar_jogo();
        }

    }
}
